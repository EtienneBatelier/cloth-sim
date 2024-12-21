#include "TissuDisque.h"

using namespace std;


//TissuChaine::TissuChaine(double m,double frot_fluide,double raideur,double l0, vector<Vecteur3D> p,SupportADessin* s)
//Masse::Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_,SupportADessin* support_)
TissuDisque::TissuDisque(double m,Vecteur3D centre, Vecteur3D rayon,double pas_radial,double frot_fluide ,double raideur,SupportADessin* s,double pas_angulaire)
    :Tissu({})
{
    //Vecteur perpendicualaire au vecteur rayon
    Vecteur3D u;
    if(rayon.get_vecteur()[1]==0 and rayon.get_vecteur()[2]==0)
    {
        Vecteur3D v(0.0,1.0,0.0);
        u=v;
    }
    else
    {
        Vecteur3D v(0.0,-rayon.get_vecteur()[2],rayon.get_vecteur()[1]);
        u=v;
    }
   // cout<<"u :"<<u<<endl;
    //nombre de masse sur une corde
    int nbr_masse(floor(rayon.norme()/pas_radial));
    double nb(nbr_masse);
    //Vecteur distance entre les masses d'une meme corde
    u.normalise();
    Vecteur3D v(u*rayon.norme()*(1.0/(nb-1)));
    double longueur(v.norme());
  //  cout<<"v :"<<v<<endl;
   // cout<<v.norme();
//Masse::Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_,SupportADessin* support_)
    Vecteur3D nul({0.0,0.0,0.0});
    masses.push_back(new Masse(m,frot_fluide,centre,nul));
    int angle(pas_angulaire);
    while(360%angle!=0)
    {
        angle++;
    }
    int nbr_chaine(360/pas_angulaire);
  //  cout<<"nbr_chaine "<<nbr_chaine<<endl;
  //  cout<<"nbr_masse "<<nbr_masse<<endl;
  //  cout<<"nbr_chaine*(nbr_masse-1)+1 "<<nbr_chaine*(nbr_masse-1)+1<<endl;

    for(int j(0);j<nbr_chaine;++j)
    {
        for(int i(1);i<nbr_masse;++i)
        {
           // cout<<"v : "<<v<<endl;
           // cout<<"norme"<<v.norme()<<endl;
           // cout<<"longueur*(nbr_masse-1) : "<<longueur*(nbr_masse-1)<<"rayon.norme()"<<rayon.norme()<<endl;
           // cout<<"centre+v*i "<<centre+v*i<<" sa norme "<<(centre+v*i).norme()<<endl;
            //cout<<"v*(nbr_masse-1)"<<(v*(nbr_masse-1)).norme()<<endl;
            masses.push_back(new Masse(m,frot_fluide,centre+v*i,nul));
            if(i==1)
            {

                connecte(0,j*(nbr_masse-1)+i,raideur,v.norme());
            }
            else
            {
                 //cout<<"masses["<<j*(nbr_masse-1)+i-1<<"]"<<endl<<masses[j*(nbr_masse-1)+i-1]<<endl;
                // cout<<"masses["<<j*(nbr_masse-1)+i<<"]"<<endl<<masses[j*(nbr_masse-1)+i]<<endl;
                 connecte(j*(nbr_masse-1)+i-1,j*(nbr_masse-1)+i,raideur,v.norme());
            }
        }
        v=(cos(angle))*v+(1-cos(angle))*(v*rayon)*rayon+(sin(angle))*(rayon^v);
      //  cout<<"prof "<<v.norme();
        v.normalise();
     //   cout<<"v normalise "<<v.norme()<<endl;
        v=v*longueur;
       // cout<<"v : "<<v<<endl;
       // cout<<"norme"<<v.norme()<<endl;
       // cout<<"longueur*(nbr_masse-1) : "<<longueur*(nbr_masse-1)<<"rayon.norme()"<<rayon.norme()<<endl;
    }
       //cout<<"Masse size "<<masses.size()<<endl;
    for(int j(0);j<nbr_chaine;j++)
    {
        for(int i(1);i<nbr_masse;++i)
        {
            Vecteur3D pi1(masses[i+j*(nbr_masse-1)]->get_position());
            if(j<nbr_chaine-1)
            {
                Vecteur3D pi2(masses[i+(j+1)*(nbr_masse-1)]->get_position());
                Vecteur3D p(pi1-pi2);
                double l0(p.norme());
                connecte(i+j*(nbr_masse-1),i+(j+1)*(nbr_masse-1),raideur,l0);

            }
            else
            {
                Vecteur3D pi2(masses[i]->get_position());
                Vecteur3D p(pi1-pi2);
                double l0(p.norme());
                connecte(i+j*(nbr_masse-1),i,raideur,l0);
            }
        }
    }
    //cout<<"Chaussette"<<endl;
    for(unsigned int i(0);i<masses.size();++i)
    {
        cout<<endl<<"Masse["<<i<<"]"<<endl<<*masses[i]<<endl;
        cout<<masses[i]<<endl;

    }
    cout<<nbr_chaine<<endl;
    cout<<nbr_masse<<endl;
    cout<<ressorts.size()<<endl;
}
