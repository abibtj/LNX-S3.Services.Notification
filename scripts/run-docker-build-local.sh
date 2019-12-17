#!/bin/bash

# Move to the root directory
cd .. 
cd ..

BUILD=./scripts/docker-build-local.sh
REPOSITORY=LNX-S3.Services.Notification

	 echo ========================================================
	 echo Building a local Docker image: $REPOSITORY
	 echo ========================================================

     cd $REPOSITORY
     $BUILD

# Beep to indicate successful compeletion
echo -ne '\007'