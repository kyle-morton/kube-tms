Deploy to K8S in this order
- kubecarrier-depl (deployment for app)
- kubecarrier-np-srv (node port for app)

To push up to dockerhub
- docker build -t kylemorton5770/kubecarrier .
- docker push kylemorton5770/kubecarrier

To force K8S to pull newest image and restart
- kubectl rollout restart deployment kubecarrier-depl