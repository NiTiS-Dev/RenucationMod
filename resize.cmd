@echo off
cd AssetsRaw
..\ImageResizer -o "../Assets" -f "*.png" -m NearestNeighbor -s 2x2
cd ..
