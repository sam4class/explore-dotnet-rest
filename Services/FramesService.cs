using SeeSharpGlasses.Models;

namespace SeeSharpGlasses.Services;

public static class FramesService
{
    static List<Frames> EyeGlasses { get; }
    static int nextId = 4;
    static FramesService()
    {
        EyeGlasses = new List<Frames>
        {
            new Frames { Id = 1, Type = "Cat-Eye" },
            new Frames { Id = 2, Type = "Aviator" },
            new Frames { Id = 3, Type = "Browline" }
        };
    }
    //GET all
    public static List<Frames> GetAll() => EyeGlasses;

    //GET by id
    public static Frames? Get(int id) => EyeGlasses.FirstOrDefault(p => p.Id == id);

    //POST
    public static void Add(Frames frames)
    {
        frames.Id = nextId++;
        EyeGlasses.Add(frames);
    }

    //DELETE
    public static void Delete(int id)
    {
        var frames = Get(id);
        if (frames is null)
            return;

        EyeGlasses.Remove(frames);
    }

    //Update
    public static void Update(Frames frames)
    {
        var index = EyeGlasses.FindIndex(p => p.Id == frames.Id);
        if (index == -1)
            return;

        EyeGlasses[index] = frames;
    }
}