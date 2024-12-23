 #include "TissuDisque.h"

using namespace std;


//Masse::Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_,SupportADessin* support_)
TissuDisque::TissuDisque(double m, Vecteur3D centre,Vecteur3D rayon,double pas_radiale, double frot_fluide, double raideur, int pas_angulaire,SupportADessin* s)
    :Tissu({},s)
{
    Vecteur3D rayon_norme(rayon*(1.0/rayon.norme()));
    //rayon_norme est juste le rayon normalise. Il sera utile pour la rotation du vecteur u (coplanaire au disque et perpendiculaire au rayon)

    Vecteur3D u;
    //u sera le Vecteur3D coplanaire au disque et perpendiculaire au rayon
    if (rayon.get_vecteur()[1]==0 and rayon.get_vecteur()[2]==0)
    {
        Vecteur3D v(0.0,1.0,0.0);
        u=v;
    }
    else
    {
        Vecteur3D v(0.0,-rayon.get_vecteur()[2],rayon.get_vecteur()[1]);
        u=v;
    }

    int nbr_masse(rayon.norme()/pas_radiale);
    //Si le pas_radiale n'est pas un diviseur de la norme du rayon une approximation se fait : le double est convertit en int


    while(360%pas_angulaire!=0)
    {
        ++pas_angulaire;
    }
    int nbr_chaine(360/pas_angulaire);
    //Si le pas angulaire n'est pas un diviseur de 360 alors on prend le diviseur au dessus

    double nb(nbr_masse);
    //pour etre sur de ne pas avoir de division euclidienne lors de 1.0/nb

    u.normalise();
    u=u*rayon.norme()*(1.0/nb);
    //On normalise u puis on multiplie u par rayon.norme()*(1.0/nb) ie on donne à la norme de u la norme du rayon puis on divise cette norme pas le nombre de masse.
    //Ainsi la norme de u est le nombre de masse par "chaine" sans compter celle de l'origine.

    double longueur(u.norme());
    //On enregistre cette norme() pour la réutiliser lorsque l'on modifie u et le tournant

    double angle_radian(pas_angulaire*2*M_PI/360.0);
    //On convertit l'angle alors exprimé en radian

    Vecteur3D nul;
    //Ce vecteur initialisé à {0.0,0.0,0.0} par le constructeur par défaut permettra d'initialisé la vitesse des masses à 0

    masses.push_back(new Masse(m,frot_fluide,centre,nul));
    //On rajoute au tableau de masse (masses) la masse d'origine

    for(int i(1);i<=nbr_masse;++i)
    {
        masses.push_back(new Masse(m,frot_fluide,centre+u*i,nul));
        connecte(i-1,i,raideur,longueur);
    }
    //On construit le reste de la chaine et on connecte chaque masse à la précédente, c'est pour cela que la masse centrale a été rajoutée en dehors de la boucle for.

    //On réitère la creation des chaines en "tournant" le vecteur u grâce à la formule donnée
    for(int j(1);j<nbr_chaine;++j)
    {
        u=cos(angle_radian)*u+(1-cos(angle_radian))*(u*rayon_norme)*rayon_norme+(sin(angle_radian))*(rayon_norme^u);
        //On va redonner la norme "longueur" au vecteur u pour s'assurer que les masses soient aux bonnes positions
        u.normalise();
        u=u*longueur;
        masses.push_back(new Masse(m,frot_fluide,centre+u,nul));
        //Creer la premiere masse de la chaine

        connecte(0,j*nbr_masse+1,raideur,longueur);
        //Connecte la masse du milieu à la première masse de la chaîne

        connecte((j-1)*nbr_masse+1,j*nbr_masse+1,raideur,(masses[(j-1)*nbr_masse+1]->get_position()-masses[j*nbr_masse+1]->get_position()).norme());
        //Connecte la première masse de la chaine à celle de la chaîne précédente.

        for(int i(2);i<=nbr_masse;++i)
        {
            masses.push_back(new Masse(m,frot_fluide,centre+u*i,nul));
            connecte(j*nbr_masse+i-1,j*nbr_masse+i,raideur,longueur);
            //Connecte chaque masse à la précédente

            connecte((j-1)*nbr_masse+i,j*nbr_masse+i,raideur,(masses[(j-1)*nbr_masse+i]->get_position()-masses[j*nbr_masse+i]->get_position()).norme());
            //Connecte les masses (qui ont la même posision sur la chaîne) d'une chaîne à celle de la chaîne précédente.
        }
    }

    for(int i(1);i<=nbr_masse;++i)
    {
       connecte(nbr_masse*(nbr_chaine-1)+i,i,raideur,(masses[nbr_masse*(nbr_chaine-1)+i]->get_position()-masses[i]->get_position()).norme());
       //Connecte les masses de la dernière chaîne aux masses de la première chaîne
    }
}

//Destructeur
TissuDisque::~TissuDisque()
{
    for(auto& m:masses)
    {
        delete m;
    }
    masses.clear();
    for(auto& r:ressorts)
    {
        delete r;
    }
    ressorts.clear();
}
