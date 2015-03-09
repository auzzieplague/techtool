
ipconfig.exe /release 
net.exe stop "dhcp client" 
net.exe stop "dns client" 
net.exe stop "network connections" 
net.exe start "dhcp client" 
net.exe start "dns client" 
net.exe start "network connections" 
ipconfig.exe /flushdns 
ipconfig.exe /renew 

netsh winsock reset catalog
netsh int ip reset

exit