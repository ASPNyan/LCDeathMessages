using System;
using System.Collections.Generic;

namespace LCDeathMessages;

public static class DeathMessages
{
    private static List<string> Unknown { get; } =
    [
        "$$ was slain.",
        "$$'s soul left their body.",
        "$$ was murdered.",
        "$$ passed.",
        "$$ heart stopped.",
        "$$ went offline.",
        "$$'s life support was unplugged.",
        "$$ turned blue.",
        "$$'s incompetence was put on display.",
        "$$ expired."
    ];

    private static List<string> Bludgeoning { get; } =
    [
        "$$ experienced skull crushing defeat.",
        "$$'s bones were shattered.",
        "$$ was whacked in the head.",
        "$$ was bludgeoned out of their misery.",
        "$$ was on the wrong end of an object.",
        "$$ found themselves before a hard place.",
        "$$'s neck was pulverised.",
        "$$ suffered a fatal blow."
    ];

    private static List<string> Gravity { get; } =
    [
        "$$ didn't bounce.",
        "$$ tripped.",
        "$$ discovered gravity.",
        "$$ thought they could fly.",
        "$$ left a small crater.",
        "$$ left an average crater.",
        "$$ left a massive crater.",
        "$$ forgot to walk on solid ground.",
        "$$ splattered."
    ];

    private static List<string> Blast { get; } =
    [
        "$$ went boom!",
        "$$ went everywhere.",
        "$$ went out with a bang.",
        "$$ was blown to smithereens.",
        "$$ detonated.",
        "$$ became a cloud of dust.",
        "$$ was ripped piece by piece in an explosion.",
        "$$ was reduced to atoms."
    ];

    private static List<string> Strangulation { get; } =
    [
        "$$'s neck was tied up with a nice bow.",
        "$$ was choked out.",
        "$$ was throttled.",
        "$$ had their breath taken away.",
        "$$ lost their breathing privileges.",
        "$$'s neck was held in high regard."
    ];

    private static List<string> Suffocation { get; } =
    [
        "$$ couldn't breathe.",
        "$$ ran out of air.",
        "$$'s lungs were empty.",
        "$$ took their last breath.",
        "$$ suffocated in the dark",
        "$$'s last breath was wasted.",
        "$$ asphyxiated.",
        "$$ experienced hypoxia.",
        "$$'s breath left them."
    ];

    private static List<string> Mauling =>
    [
        "$$ was slain.",
        "$$ was eviscerated.",
        "$$ was murdered.",
        "$$'s face was torn off.",
        "$$'s entrails were ripped out.",
        "$$ got massacred.",
        "$$ was torn in half.",
        "$$'s body was mangled.",
        "$$'s vital organs were ruptured.",
        $"$$ was removed from {Plugin.RoundData.currentLevel.name}."
    ];

    private static List<string> Gunshots { get; } =
    [
        "$$ was given some extra holes.",
        "$$ became partly see-through.",
        "$$ had lead forcefully implanted.",
        "$$ was target practice.",
        "$$ didn't hear the gunshots.",
        "$$ wasn't Neo.",
        "$$ found out that bullets hurt.",
        "$$ was shot down.",
        "$$ walked into a training range."
    ];

    private static List<string> Crushing { get; } =
    [
        "$$ found crushing defeat.",
        "$$ couldn't handle the pressure.",
        "$$'s life was crushed.",
        "$$ found too much weight upon them.",
        "$$ suffered under pressure.",
        "$$ discovered that gravity doesn't just make them fall."
    ];

    private static List<string> Drowning { get; } =
    [
        "$$ is shark food.",
        "$$ is sleeping with the fish.",
        "$$ drowned.",
        "$$ tried to drink a lake.",
        "$$ discovered Atlantis.",
        "$$ drank water the wrong way.",
        "$$ didn't have gills."
    ];

    private static List<string> Abandoned { get; } =
    [
        "$$ was left behind.",
        "$$ was forgotten.",
        "$$ wasn't important.",
        "$$ decided to stay home.",
        "$$ lost track of time.",
        "$$ forgot the last part of the mission."
    ];

    private static List<string> Electrocution { get; } =
    [
        "$$ couldn't figure out watt happened.",
        "$$ couldn't contain the watts.",
        "$$ was turned into a battery.",
        "$$ became a lightning rod.",
        "$$'s positive life force became negative.",
        "$$ was zapped.",
        "$$ touched the wrong wire.",
        "$$ is no longer live."
    ];

    public static string Get(CauseOfDeath cause, string username)
    {
        Random rng = new Random();
        return (cause switch
        {
            CauseOfDeath.Unknown => Unknown[rng.Next(0, Unknown.Count)],
            CauseOfDeath.Bludgeoning => Bludgeoning[rng.Next(0, Bludgeoning.Count)],
            CauseOfDeath.Gravity => Gravity[rng.Next(0, Gravity.Count)],
            CauseOfDeath.Blast => Blast[rng.Next(0, Blast.Count)],
            CauseOfDeath.Strangulation => Strangulation[rng.Next(0, Strangulation.Count)],
            CauseOfDeath.Suffocation => Suffocation[rng.Next(0, Suffocation.Count)],
            CauseOfDeath.Mauling => Mauling[rng.Next(0, Mauling.Count)],
            CauseOfDeath.Gunshots => Gunshots[rng.Next(0, Gunshots.Count)],
            CauseOfDeath.Crushing => Crushing[rng.Next(0, Crushing.Count)],
            CauseOfDeath.Drowning => Drowning[rng.Next(0, Drowning.Count)],
            CauseOfDeath.Abandoned => Abandoned[rng.Next(0, Abandoned.Count)],
            CauseOfDeath.Electrocution => Electrocution[rng.Next(0, Electrocution.Count)],
            _ => string.Empty
        }).Replace("$$", username);
    }
}