To push up to dockerhub
- docker build -t kylemorton5770/kubetms
- docker push kylemorton5770/kubetms

To force K8S to pull newest image and restart
- kubectl rollout restart deployment kubetms-depl

Acme.com for ingress service needs to be defined in your local HOST file
- C:\Windows\System32\drivers\etc\hosts 
- Add a new entry here that points to the loopback address (127.0.0.1 acme.com)