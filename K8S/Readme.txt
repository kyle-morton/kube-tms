Deploy to K8S in this order
- {app}-depl (deployment for each app)
- {app}-np-srv (node port for each app)
- ingress-srv (remember to change host file - see below. Needs to be removed and redeployed on each new microservice deployment)
- local-pvc (set up persistent volume for DB)
- mssql-kubetms-depl (set up db)

Acme.com for ingress service needs to be defined in your local HOST file
- C:\Windows\System32\drivers\etc\hosts 
- Add a new entry here that points to the loopback address (127.0.0.1 acme.com)