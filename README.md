# Kubernetes Assignment: Product.API
## Overview
A simple web application that serves product data, Dockerized and deployed on a Kubernetes cluster.

## Steps for Kubernetes Deployment

### 1. Dockerize the Web Application
- Create a Dockerfile for the web application
- Build the Docker image using the command: docker build -t productapi:1.0 .

### 2. Push Docker Image to Docker Hub
- Tag the Docker image with a version number (e.g. productapi:1.0)
- Push the Docker image to Docker Hub using the command: docker push productapi:1.0

### 3. Set up Minikube for Containerizing Images
- Start Minikube using the command: minikube start
- Verify the cluster information using the command: kubectl cluster-info

### 4. Load the Docker Image into Minikube
- Load the Docker image into Minikube using the command: minikube image load productapi:1.0

### 5. Create and Apply Deployment and Service Files
- Create a deployment YAML file (e.g. deployment.yaml) that defines the deployment configuration
- Create a service YAML file (e.g. service.yaml) that defines the service configuration

### 6. Apply the deployment and service files using the commands:
- kubectl apply -f deployment.yaml
- kubectl apply -f service.yaml

### 7. Verify Deployment and Pods
- Verify the deployment using the command: kubectl get deployments
- Verify the pods using the command: kubectl get pods

### 8. Verify Services
- Verify the services using the command: kubectl get services

### 9. Access the Service
-Access the service using the command: minikube service productapi-service

### 10. Scale the Deployment
-Scale the deployment using the command: kubectl scale deployment productapi-deployment --replicas=4