namespace Sewer{
using ClothPiece;
using Vector3D;
using Hook;
using System;
using Mass;
using MassGraphicalUnity;
using System.Collections.Generic;

unsafe static class Sewer
{
    private static (Vector3D, Vector3D, Vector3D) normalVectorToOrthogonalMatrix(Vector3D normalToPlane)
    {
        if (normalToPlane.SquaredNorm() == 0) throw new ArgumentException("Cannot find a plane that is normal to a zero vector");
        float[] normal = normalToPlane.GetVector();
        if (normal[0] == 0 && normal[1] == 0) 
        {
            return (new Vector3D(1, 0, 0), new Vector3D(0, 1, 0), normalToPlane.ScalarMult(normalToPlane.Norm()));
        }

        Vector3D firstColumn = normalToPlane^new Vector3D(0, 0, 1);
        firstColumn.Normalize();
        Vector3D secondColumn = normalToPlane^firstColumn;
        secondColumn.Normalize();
        return (firstColumn, secondColumn, normalToPlane.ScalarMult(1/normalToPlane.Norm()));
    }

    private static Vector3D matrixVectorMult(Vector3D firstColumn, Vector3D secondColumn, Vector3D thirdColumn, Vector3D v)
    {
        float[] vector = v.GetVector();
        float[] c1 = firstColumn.GetVector();
        float[] c2 = secondColumn.GetVector();
        float[] c3 = thirdColumn.GetVector();
        float[] result = new float[3];

        result[0] = c1[0]*vector[0] + c2[0]*vector[1] + c3[0]*vector[2];
        result[1] = c1[1]*vector[0] + c2[1]*vector[1] + c3[1]*vector[2];
        result[2] = c1[2]*vector[0] + c2[2]*vector[1] + c3[2]*vector[2];

        return new Vector3D(result);
    }

    #nullable enable
    public static (ClothPiece, Hook) HookedRectangle(int a, int b, float* mass, float* dampingCoefficient, float* stiffness, float* restLength, Vector3D? center = null, Vector3D? normalToPlane = null, List<string>? hookTypes = null)
    {
        if (center is null) {center = new Vector3D(0, 0, 10);}
        if (normalToPlane is null) {normalToPlane = new Vector3D(0, 0, 1);}

        (Vector3D firstColumn, Vector3D secondColumn, Vector3D thirdColumn) = normalVectorToOrthogonalMatrix(normalToPlane);

        List<Mass> masses = new List<Mass>{};
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                masses.Add(new MassGraphicalUnity(mass, dampingCoefficient, center + matrixVectorMult(firstColumn, secondColumn, thirdColumn, new Vector3D(i - a/2.0f, j - b/2.0f, 0)), 1.2f));
            }
        }
        ClothPiece clothPiece = new ClothPiece(masses);
        float dist;
        for (int i = 0; i < clothPiece.masses.Count; i++)
        {
            for (int j = 0; j < clothPiece.masses.Count; j++)
            {
                dist = (clothPiece.masses[i].GetPosition() - clothPiece.masses[j].GetPosition()).SquaredNorm();
                if (0 < dist && dist < 1.1f) {clothPiece.Connect(i, j, stiffness, restLength);}
            }
        }


        if (hookTypes is null) {return (clothPiece, new Hook());} 
        List<string> hookTypesCopy = hookTypes;
        List<Mass> hookedMasses = new List<Mass>{};
        if (hookTypes.Contains("allSides")) 
        {
            hookTypesCopy.Add("firstSide");
            hookTypesCopy.Add("secondSide");
            hookTypesCopy.Add("thirdSide");
            hookTypesCopy.Add("fourthSide");
        }
        if (hookTypes.Contains("allCorners"))
        {
            hookTypesCopy.Add("firstCorner");
            hookTypesCopy.Add("secondCorner");
            hookTypesCopy.Add("thirdCorner");
            hookTypesCopy.Add("fourthCorner");
        }
        foreach (string hookType in hookTypesCopy)
        {
            
            if (hookType == "firstSide") {for (int i = 0; i < a; i++) {hookedMasses.Add(masses[i*b]);}}
            if (hookType == "secondSide") {for (int j = (a-1)*b; j < a*b; j++) {hookedMasses.Add(masses[j]);}}
            if (hookType == "thirdSide") {for (int i = 0; i < a; i++) {hookedMasses.Add(masses[b-1+i*b]);}}
            if (hookType == "fourthSide") {for (int j = 0; j < b; j++) {hookedMasses.Add(masses[j]);}}
            if (hookType == "firstCorner") {hookedMasses.Add(masses[0]);}
            if (hookType == "secondCorner") {hookedMasses.Add(masses[(a-1)*b]);}
            if (hookType == "thirdCorner") {hookedMasses.Add(masses[a*b-1]);}
            if (hookType == "fourthCorner") {hookedMasses.Add(masses[b-1]);}
            
        }

        Hook hook = new Hook(hookedMasses);
        return (clothPiece, hook);
    }
}
}