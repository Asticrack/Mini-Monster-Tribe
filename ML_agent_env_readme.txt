Pour installer l'environnement de dev ML_agent :
1 : télécharger la derniere version de python dispo : https://www.python.org/downloads/release/python-392/

2 : l'installer 

3 : Sur win10, pour lancer python il faut entrer "py" dans le cmd, si il est bien installé, "exit()"

4 : Dans le cmd, faire un cd vers le dossier du projet unity (chez moi : C:\Users\alexi\Documents\GitHub\Mini-Monster-Tribe)

5 : on creer un environnement python virtuel dans le dossier venv avec la commande 
py -m venv venv

6 : on active l'environnement virtuel en lancant le fichier activate dans ce nouveau dossier venv avec la commande
venv\Scripts\activate

7 : vous pouvez voir si vous etes bien dans votre envorionnement python avec le (venv) affiché à gauche dans le cmd

8 : une fois dans l'environnement, on va ds un premier temps upgrade le pip avec la commande :
python -m pip install --upgrade pip

9 : on install maintenant les librairies necessaires avec les commandes :
pip install torch -f https://download.pytorch.org/whl/torch_stable.html
pip install mlagents
pip install mlagents --use-feature=2020-resolve (si il y a eu une erreure lors de l'install de mlagents

10 : pour voir si tout est bon la commande :
mlagents-learn --help 
Si il n'y a pas de wining, c'est good !

11 : lancer le projet unity mini monster tribe, aller dans :
window => package manager => aller dans les package : unity registry => trouver ML Agents et l'installer (prenons la 1.8.1 preview , vous pouver la voir si vous activez l'option de l'écrous => advanced project setting => enable preview packages) )

12 : pour verifier que le MLagent est bien lo, vous devrier pouvoir ajouter un componant "ML Agents"

FINI : Et et voila fin pret pour l'incroyable experience du machine learning !


tips pour l'entrainement, la commande pr lancer un entrainement est :
mlagents-learn 
(vous devez voir le logo ascii unity)
une fois la commande lancée, il suffis d appuyer sur plays pr lancer le training

