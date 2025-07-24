import os
from kubernetes import client, config

def main():
    """
    Se conecta al clúster de Kubernetes desde dentro de un Pod y revisa
    el estado de todos los Pods en todos los namespaces.
    """
    print("🚀 Iniciando la revisión de Pods en el clúster...")

    # Carga la configuración del clúster desde el ServiceAccount del Pod.
    # Esto es lo que permite que el script funcione DENTRO de Kubernetes.
    config.load_incluster_config()

    # Crea un cliente para interactuar con la API Core V1 de Kubernetes.
    v1 = client.CoreV1Api()

    # Obtiene una lista de todos los Pods en todos los namespaces.
    pod_list = v1.list_pod_for_all_namespaces(watch=False)

    print(f"✅ Se encontraron {len(pod_list.items)} Pods en total.")
    
    non_running_pods = []

    for pod in pod_list.items:
        # Un Pod saludable está 'Running' o ya completó su tarea 'Succeeded'.
        # Buscamos cualquier cosa que no sea eso: 'Pending', 'Failed', 'Unknown'.
        if pod.status.phase not in ['Running', 'Succeeded']:
            non_running_pods.append({
                "name": pod.metadata.name,
                "namespace": pod.metadata.namespace,
                "status": pod.status.phase,
                "reason": pod.status.reason
            })

    if non_running_pods:
        print("\n⚠️ ¡Alerta! Se encontraron Pods con problemas:")
        for pod in non_running_pods:
            print(f"  - Namespace: {pod['namespace']}, Pod: {pod['name']}, Estado: {pod['status']}, Razón: {pod['reason']}")
    else:
        print("\n👍 Todo en orden. Todos los Pods están en estado 'Running' o 'Succeeded'.")

if __name__ == '__main__':
    main()