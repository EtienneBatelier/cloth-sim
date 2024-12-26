namespace Hook;
using Constraint;
using Vector3D;
using Mass;
using ClothPiece;

class Hook : Constraint
{
    private List<Mass> affectedMasses; 

    //Constructor

    public Hook(List<Mass> affectedMasses_) {affectedMasses = affectedMasses_;}
    public Hook(Vector3D center, double radius, List<ClothPiece> clothPieces) 
    {
        affectedMasses = [];
        foreach (ClothPiece clothPiece in clothPieces)
        {
            foreach (Mass m in clothPiece.GetMasses())
            {
                if ((m.GetPosition() - center).SquaredNorm() <= radius*radius) {affectedMasses.Add(m);}
            }
        } 
    }

    //Other methods

    public override bool Applies(Mass m , double time) 
    {
        return base.start <= time && base.end >= time && affectedMasses.Contains(m); 
    } 
    public override Vector3D Force(Mass m, double time) {return new Vector3D();}
    public override void Effect(Mass m) {m.Immobilize();}
}