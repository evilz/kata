# Introduction

## Objectifs

Le premier objectif de ce Kata est identique � tous les Kata: S�am�liorer dans la technique du TDD, par l��criture de tests, l��criture du code. Puis le refactoring des tests et du code � cause des changements de sp�cifications (complexification de l�algo, exception � la r�gle, besoin d�am�lioration techniques induit,�).

Le deuxi�me objectif de ce kata est de vous donner une id�e, certes sommaire mais id�e tout de m�me, de comment peut fonctionner un pricer � On Demand � dans la finance de march�.

Enfin, pour certaines �tapes on va voir les � limites � des tests unitaires, je vous laisse d�battre de s�il faut trouver des moyens de les franchir ou pas. Et si oui de comment le faire.

Auditoire:

Pour r�aliser ce Kata vous devez � ma�triser � un langage de programmation, ainsi qu�un framework de test. Il n�y a pas vraiment besoin de connaissance en finance, mais il est mieux d�y avoir une certaine sensibilit�. Ce kata a aussi une relative complexit�, il est bien d�en avoir fait des tr�s simples avant de le commencer (ex: chercher Kata FizzBuzz sur le net).

Etapes:

Pour chaque �tape, il y a un �nonc� que j�ai essay� de faire le plus clair possible. Il y a aussi un paragraphe nomm�: � A la fin de l��tape �. Il s�agit de quelques questions pouvant amener � une phase de refactoring ou non. Le but �tant de challenger/r�fl�chir � ce que l�on � fait lors de l��tape. Il n�y a pas forc�ment de bonne r�ponse absolue � ces questions. Ne trichez pas et lisez le qu�une fois l��tape r�solue ;-)

## Etape 1: Extrapolation du prix simple

Enonc�:

Il faut cr�er un MiniPricer pouvant donner le prix dans le futur d�un instrument en fonction de:

La date dans le futur du prix.
Le prix actuel  de l�instrument.
La volatilit� moyenne journali�re en % de l�instrument.
Sachant que la volatilit� moyenne journali�re repr�sente sa variation prix moyenne d�un jour � l�autre. En d�autres termes,  si l�instrument vaut P � J, � J+1 il vaut P x (1+V/100) en moyenne. O� V est la volatilit� journali�re moyenne de l�instrument exprim�e en %

Note: Pour cette �tape on consid�re que la variation de prix de l�instrument est toujours �gale � sa volatilit� moyenne.

A la fin de l�tape:


Les march�s sont ferm�s le samedi, le dimanche, et les jours f�ri�s, donc la variation de prix de l�instrument est nulle, ces jours l�. Y avez vous pens� ?

Note: pour simplifier on peut ne consid�rer que les jours f�ri�s � date fixe 01/01, 01/05, 08/05� et pas ceux comme le lundi de pentec�te, Lundi de P�ques� Toujours pour simplifier, on peut en consid�rer que les 3 premiers, donn�e pr�c�demment.

## Etape 2: Le caract�re al�atoire

 Enonc�:

En fait, un instrument ne varie jamais exactement de sa volatilit� moyenne tous les jours. Comme son nom le dit C�est une moyenne. De plus la valeur de la volatilit� est une valeur absolue, donc le prix de l�instrument peut augmenter ou descendre de cette valeur.

Revoir la m�thode de calcul du prix en consid�rant que chaque jour soit le prix augmente de la volatilit� moyenne, soit le prix ne bouge pas, soit le prix baisse de la volatilit� moyenne. Le choix entre les trois mouvements possibles devant �tre al�atoire.

A la fin de l��tape:

Comment avez vous fait pour �crire un test sachant que le r�sultat de la m�thode � tester est plus ou moins al�atoire ?

Avez vous utilis� des tests sur les extremums ( nb jours ouvr�s x volatilit� x -1 >= Prix >= nb jours ouvr�s x volatilit� x 1) ?

Avez vous utilis� un faux (mock) g�n�rateur de nombre al�atoire en v�rifiant le nombre de fois o� il a �t� appel� par exemple ?

## Etape 3: Mont�-Carlo

Enonc�:

En fait faire un seul tirage al�atoire par jour n�est pas du tout satisfaisant d�un point de vue math�matique. Une meilleure strat�gie est de cr�er un grand nombre de trajectoires de prix et d�en faire la moyenne. Une trajectoire de prix �tant ce qu�on a fait � l��tape pr�c�dente. A savoir tous les jours on fait un tirage au sort de la variation du prix � appliquer, et ce pour chaque jour � consid�rer. C�est ce qu�on appelle utiliser la m�thode de Mont�-Carlo (grand nombre d�al�as en entr�e d�un processus connu et moyenne au final).

A la fin de l��tape:

Peut-on choisir le nombre de trajectoires ? Devrait-on d�apr�s l��nonc� ?

Avez vous touch� aux tests pr�c�dents ? Comment verifier que l�algorithme � bien chang� sans casser l�encapsulation ?

Avez vous mis en parall�le  le calcul des trajectoires ? Si oui, doit/peut on le v�rifier par un test ?

Etape 4: Le panier d�instruments

Enonc�:

Pour aller plus vite, on veut pricer tous les instruments d�un m�me panier en un coup. La m�thode que l�on va appliquer est la suivante. On va pricer un instrument dit pivot selon la m�thode pr�c�dente. Et gr�ce � la corr�lation moyenne des autres instruments par rapport a cet instrument pivot, on calcul la variation de prix de ces instruments. La corr�lation repr�sente le lien entre la variation de prix de deux actifs. Elle est g�n�ralement exprim�e de mani�re sign�e, mais en %. A savoir si la corr�lation entre deux instruments vaut -1, cela veut dire que quand l�un monte de X%, l�autre baisse de X%

A la fin de l��tape:

Peut-on toujours pricer qu�un seul instrument ? Avez-vous gard� vos premiers tests ? Les avez vous refactoris�s ?

Ce changement de sp�cification a-t-il engendr� un changement de l�API de votre MiniPricer ? Est-ce n�cessaire/bien ?

## Etape 5: La pr�cision sur demande

Avertissement:

Cette �tape n�apporte pas grand chose en termes de TDD ou m�thodologie de travail, il s�agit juste de changer l�algo de pricing pour plus de commodit� de l�utilisateur. En gros c�est l��tape bonus. Ceux qui ne voudrait pas la faire, allez � la fin directement.

Enonc�:

On doit pouvoir choisir la pr�cision du prix d�termin� par le pricer. On doit pouvoir dire au pricer que l�on veut un prix pr�cis � 0.01� pr�s.

Pour ceux qui s�cheraient compl�ment sur l�algo � mettre en oeuvre voici une petite astuce: la pr�cision du prix d�pend du nombre de trajectoires calcul�es. Plus on a de trajectoires plus la pr�cision est grande. Un moyen simple de le faire est de calculer un certains nombres de trajectoires, calcul� la moyenne de la distance de chacune des trajectoires par rapport � la moyenne (�cart type). De v�rifier que l��cart type est en dessous de la pr�cision demand�e. Si ce n�est pas le cas recommencer en ajoutant les trajectoires les nouvelles trajectoires aux anciennes et en recalculant le nouvel �cart type et ainsi de suite. La diff�rence de prix �tant born�e entre les trajectoires, + ou � nb jour ouvr�s x Volatilit� aux extremums, plus le nombre de trajectoires augmente, plus la pr�cision aussi.

## Fin du kata

c�est le moment de faire le m�nage !!!

Avez vous du code en commentaire ?

Avez vous des tests en commentaires ?

Avez vous des tests des inutiles ou qu�il ne passe pas ?

Avez vous des commentaires explicatifs ?

Combien avez vous fait de classe ?

Combien avez vous fait de m�thode ?

Bravo !