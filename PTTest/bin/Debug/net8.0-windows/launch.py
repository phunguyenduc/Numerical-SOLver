import math
import cv2
import numpy as np
import csv
from ultralytics import YOLO

def calculate_distance(bbox1, bbox2):
  # Calculate the distance between the centers of two bounding boxes
  _, x1, y1, _, _ = bbox1
  _, x2, y2, _, _ = bbox2
  center1 = (x1 + _/2, y1 + _/2)
  center2 = (x2 + _/2, y2 + _/2)
  return math.sqrt((center1[0] - center2[0])**2 + (center1[1] - center2[1])**2)

def grouping(bboxes, threshold):
  # Initialize empty list for groups
  groups = []

  # Iterate through bounding boxes
  for bbox in bboxes:
    # Flag to check if bbox is grouped
    grouped = False

    # Iterate through existing groups
    for group in groups:
      # Check distance to each bbox in group
      for group_bbox in group:
        if calculate_distance(bbox, group_bbox) < threshold:
          # Add bbox to the group
          group.append(bbox)
          grouped = True
          break
      if grouped:
        break  # No need to check other groups

    if not grouped:
      # If bbox doesn't belong to any existing group, create a new group
      groups.append([bbox])

  return groups

# Load YOLO model
model = YOLO("best.pt")

# Path to the image
source = "test.jpg"
img = cv2.imread(source)

if img is None:
    print("Error: Could not read image.")
    exit()

# Detect objects in the image
<<<<<<< HEAD
results = model(source=img, iou=0, conf=0.4)
=======
results = model(source=img, iou=0, conf=0.4)
>>>>>>> 10b2366 (fix some bugs)
result = results[0]

bboxes = []
labels = []

# Parse detection results
for item in result:
    x, y, w, h = item.boxes.xywhn[0]
    label = int(item.boxes.cls[0]) - 2  # Assuming class label is the digit itself
    bboxes.append((label, x, y, w, h))
    # labels.append(label)

bboxes.sort(key = lambda x: x[2])

# Group bounding boxes and labels
threshold = 0.15  # Adjust this threshold as needed
grouped_bboxes_labels = grouping(bboxes, threshold)
for group in grouped_bboxes_labels:
  group.sort(key = lambda x: x[1])  

grouped_bboxes_labels.sort(key = lambda x: x[0][2])

with open('output.csv', mode='w', newline='') as file:
    writer = csv.writer(file)

    for i, groups in enumerate(grouped_bboxes_labels):
        group_labels = []
        for group in groups:
          if group[0] == -2:
            group_labels.append('-')
          elif group[0] == -1:
              group_labels.append('.')
          else:
              group_labels.append(str(group[0]))

        group_digits = "".join(group_labels)
        print(group_digits)
        writer.writerow([group_digits])
