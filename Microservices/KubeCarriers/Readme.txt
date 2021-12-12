Deploy to K8S in this order
- kubecustomers-depl (deployment for app)
- kubecustomers-np-srv (node port for app)

To push up to dockerhub
- docker build -t kylemorton5770/kubecustomers
- docker push kylemorton5770/kubecustomers

To force K8S to pull newest image and restart
- kubectl rollout restart deployment kubecustomers-depl