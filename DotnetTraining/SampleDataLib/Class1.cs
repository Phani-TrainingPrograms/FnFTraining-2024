namespace SampleDataLib
{
    /*
     * Classes inside a DLL are recommended to be public, so that they are accessible across the projects. If the class is internal, it is scoped only to the current project.
     * 
     */

    public class MathComponent
    {
        public double AddFunc(double v1, double v2) => v1 + v2;

        public double SubFunc(double v1, double v2) => v1 - v2;

    }
}
