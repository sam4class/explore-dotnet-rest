using SeeSharpGlasses.Models;

namespace SeeSharpGlasses.Services;

public static class GlassesService
{
    static List<Glasses> EyeGlasses { get; }
    static int nextId = 4;
    static GlassesService()
    {
        EyeGlasses = new List<Glasses>
        {
            new Glasses { Id = 1, Name = "Ray-Ban", Color = "Brown", Shape = "browline" },
            new Glasses{ Id = 2, Name = "Ottoto Bellona", Color = "Pink", Shape = "Oval" },
            new Glasses { Id = 3, Name = "Oakley", Color = "Gunmetal", Shape = "Rectangle" }
        };
    }
    //GET all
    public static List<Glasses> GetAll() => EyeGlasses;

    //GET by id
    public static Glasses? Get(int id) => EyeGlasses.FirstOrDefault(p => p.Id == id);

    //POST
    public static void Add(Glasses glasses)
    {
        glasses.Id = nextId++;
        EyeGlasses.Add(glasses);
    }

    //DELETE
    public static void Delete(int id)
    {
        var glasses = Get(id);
        if (glasses is null)
            return;

        EyeGlasses.Remove(glasses);
    }

    //Update
    public static void Update(Glasses glasses)
    {
        var index = EyeGlasses.FindIndex(p => p.Id == glasses.Id);
        if (index == -1)
            return;

        EyeGlasses[index] = glasses;
    }
}