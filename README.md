# Test et validation

## Difficultés lié à la validation

Dans son état actuel, le programme est difficile à valider en raison de multiples points : 

- Les méthodes sont longues et impliquent de nombreux niveaux d'indentation, augmentant la complexité du code.
- Certaines méthodes enchaînent plusieurs conditions différentes, le tout au sein de 2 boucles while imbriqués.
- À un endroit du code, on retrouve l'utilisation d'un `goto` qui agis comme une boucle pour pour lire les entrées de l'utilisateur.
- la vérification de victoire est codé en dur à travers une énorme condition de AND et OR enchaînés à la suite.
- dans `tourJoueur`, le code contiens des condition imbriqués dans un switch, lui même dans une boucle while.
- Dans le puissance 4, il reste du code mort commenté dans le fichier.


Tous ces points rendent le code difficile à lire, à comprendre et à valider, de part la longueur du code
ou la complexité des conditions. (imbrication de boucles, de conditions, de switch, de goto, etc.

## Les méthodes de résolution de ces problèmes

Pour résoudre ces problèmes, il sera envisageable de mettre en place certaines choses :

- Diviser les méthodes en plusieurs méthodes plus petites, pour réduire la complexité du code
- Utiliser des structures de données pour simplifier la vérification de victoire
- Réduire l'imbrication des boucles et des conditions
- Remplacer `goto` par des boucles
- Supprimer le code mort
- Utiliser des tests unitaires pour valider le code et s'assurer de son bon fonctionnement
- Ajouter des conditions de contrôle pour s'assurer des paramètres d'entré des méthodes
