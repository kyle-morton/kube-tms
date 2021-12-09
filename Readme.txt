Deploy to K8S in this order
- kubetms-depl (deployment for app)
- kubetms-np-srv (node port for app)
- ingress-srv (remember to change host file - see below)
- local-pvc (set up persistent volume for DB)
- mssql-kubetms-depl (set up db)

To push up to dockerhub
- docker build -t kylemorton5770/kubetms
- docker push kylemorton5770/kubetms

To force K8S to pull newest image and restart
- kubectl rollout restart deployment kubetms-depl

Acme.com for ingress service needs to be defined in your local HOST file
- C:\Windows\System32\drivers\etc\hosts 
- Add a new entry here that points to the loopback address (127.0.0.1 acme.com)