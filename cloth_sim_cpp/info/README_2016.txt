READ ME : Etienne BATELIER et Victoria DESMARQUEST, Equipe 62

1 - Nous avons tout fait jusqu'à P14. Nous avons ajouté aux consignes : 
	- Le dessin des ressorts, evolutif en fonction de la forces qu'ils appliquent aux masses (de plus en plus rouge au fur et a mesure que la force est importante, le rouge 100% (1, 0, 0) étant atteint à 250 N (en considerant les unites comme S.I.)).
	- Le changement dynamique d'integrateur (entre Euler et Newmark uniquement), à l'aide de la touche I.


2 - Nous avons une version graphique avec la bibliothèque Qt (nous avons utilisé la version deja installées sur les machines virutelles, Qt 5.2.1 il me semble).

3-  Jusqu'à la semaine 6 nous avons passé 2 heures chacun sur le projet. Par la suite nous sommes passés à environ 5 heures chacun.

4 -
	a - Quel fichier correspond à quoi?
Tous les fichiers du repertoire general ont le nom qui a été demandé dans les instructions du projet (Vecteur3D.h et Vecteur3D.cc correspondent à la classe Vecteur3D, Masse.h et Masse.cc à la classe Masse, etc...).

	b - Comment installer/compiler votre projet
Pour compiler la version finale, il faut ouvrir projet.pro avec Qt Creator, "build", puis "run". Le main de la version graphique que nous avons fourni simule une demonstration des derniers exercices :
- Un tissu rectangulaire de dimensions 20*20 contraint par des crochets en forme de table ronde,
- Un tissu disque de rayon 10 non soumis a la gravité qui subit un impulsion sinusoidale (effet méduse :-)),
- Un tissu composé de deux tissus rectangles superposables legerement decales.

	c - Que faut-il regarder particulièrement dans votre projet?

Il n'y a rien de particulier à regarder en dehors des étapes demandées. Nous n'avons pas fait d'extension particulièrement visuelle, à part le dessin des ressorts.

5 - Les fichiers tests compilent tous et sont dans le repertoire "Tests" prevu a cet effet. Pour les recompiler, il suffit de les copier coller dans le main_text.cc. Par defaut, c'est le troisieme test de l'exercice P7 que nous avons laissé.
