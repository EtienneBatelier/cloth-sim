#ifndef VUEOPENGL_H
#define VUEOPENGL_H

#include <QOpenGLShaderProgram> // Classe qui regroupe les fonctions OpenGL liées aux shaders
#include <QMatrix4x4>
#include "SupportADessin.h"
#include "Vecteur3D.h"

class VueOpenGL : public SupportADessin {
 public:
  // méthode(s) de dessin (héritée(s) de SupportADessin)
  virtual void dessine(Systeme const& a_dessiner) override;
  virtual void dessine(Tissu const& a_dessiner) override;
  virtual void dessine(Masse const& a_dessiner);

  void dessine_ressorts(Tissu const& t);
  void dessine_axes();

  // méthodes de (ré-)initialisation
  void init();
  void initializePosition();

  // méthode set
  void setProjection(QMatrix4x4 const& projection)
  { prog.setUniformValue("projection", projection); }

  // Méthodes set
  void translate(double x, double y, double z);
  void rotate(double angle, double dir_x, double dir_y, double dir_z);
  
  // méthode utilitaire pour simplifier
  void dessine_cube(QMatrix4x4 const& point_de_vue = QMatrix4x4() );
  void dessine_ligne(Vecteur3D, Vecteur3D, double, double, double);

 private:
  // Un shader OpenGL encapsulé dans une classe Qt
  QOpenGLShaderProgram prog;

  // Caméra
  QMatrix4x4 matrice_vue;
};

#endif
