﻿using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using BGME.BattleThemes.Config;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;

namespace BattleThemes.Template;

public class Mod : ModBase
{
    private readonly IModLoader modLoader;
    private readonly IReloadedHooks? hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly ThemeConfig themeConfig;

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

        this.themeConfig = new(this.modLoader, this.modConfig, this.config, this.log);

        /* Connect the battle theme files to the config. */
        /* Steps:
         * 1. Place battle theme files in: MOD_FOLDER/battle-themes/options
         * 2. Add a config setting for it in: public class Config : Configurable<Config>
         * 3. Edit/copy and paste the line below with your new setting and the theme file it enables.
         * 
         * For example, right now the config has a "P4G" setting which enables "p4g.theme.pme" in the options folder.
         */

        this.themeConfig.AddSetting(nameof(this.config.Random), "allrandom.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.ERAMTHGIN), "eramthgin.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.StringsOfFate), "stringsoffate.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.Vengeance), "vengeance.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.ManMega), "manmega.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.SubReality), "subreality.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.Spellbound), "spellbound.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.TheHivemind), "hivemind.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.MegaMurder), "megamurder.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.ArmedAndDangerous), "armedanddangerous.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.Anywhere), "anywhere.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.TheUnfairground), "unfairground.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.DeathSentence), "deathsentence.theme.pme");


        /*-------------------------------------------------------*/
        this.themeConfig.Initialize();
    }

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        config = configuration;
        log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}

public class Config : Configurable<Config>
{
    /* ADD CONFIG SETTINGS HERE */

    [Category("All Random")]
    [DisplayName("Randomise Everything")]
    [Description("Context dependent battle music from EVERYWHERE. Advantage\nbattles will play Mega Murder, while\ndisadvantage battles will play Anywhere or Armed and\nDangerous.\n\nVictory theme: Contestant Eliminated\n\nI wanted Death Sentence and The Unfairground\nfor the Reaper, but idk how to do that lmao.")]
    [DefaultValue(true)]
    public bool Random { get; set; } = true;

    [Category("MYTHOS")]
    [DisplayName("Spellbound")]
    [Description("Plays Spellbound, aka The Beast Within, Blackwood's boss theme from\nThe Great Summoning., from rabbithole.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool Spellbound { get; set; } = true;

    [Category("MYTHOS")]
    [DisplayName("Strings of Fate")]
    [Description("Plays Strings of Fate, Karuma's boss theme from The Great Summoning.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool StringsOfFate { get; set; } = true;

    [Category("MYTHOS")]
    [DisplayName("Sub-Reality")]
    [Description("Plays Sub-Reality, Obscura's boss theme from Divine Intervention.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool SubReality { get; set; } = true;

    [Category("MYTHOS")]
    [DisplayName("The UnFairground")]
    [Description("Plays The UnFairground, Calamitus' boss theme from Divine Intervention.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool TheUnfairground { get; set; } = true;

    [Category("MYTHOS")]
    [DisplayName("ERAMTHGIN")]
    [Description("Plays ERAMTHGIN, the normal battle theme from FLIPSIDE.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool ERAMTHGIN { get; set; } = true;

    [Category("MYTHOS (unreleased)")]
    [DisplayName("The Hivemind")]
    [Description("Plays The Hivemind, the normal battle theme from Attack of the Killer\nRobot Crab Monsters who Came From Outer Space.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool TheHivemind { get; set; } = true;

    [Category("MYTHOS (unreleased)")]
    [DisplayName("MAN-MEGA")]
    [Description("Take a wild guess as to whose theme this is.\nFrom Attack of the Killer Robot Crab Monsters\nwho Came From Outer Space.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool ManMega { get; set; } = true;

    [Category("MYTHOS (unreleased)")]
    [DisplayName("Vengeance")]
    [Description("Plays Prince Frewyn's boss theme, from A World at War.\n\nVictory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool Vengeance { get; set; } = true;

    [Category("rabbithole")]
    [DisplayName("Mega Murder")]
    [Description("Plays Mega Murder, the combat music from rabbithole.\n\nNo victory theme, only MURDER.")]
    [DefaultValue(true)]
    public bool MegaMurder { get; set; } = true;

    [Category("rabbithole")]
    [DisplayName("Anywhere")]
    [Description("Plays Anywhere, the 100% security theme from rabbithole.\n\nVictory theme: Black and Blue")]
    [DefaultValue(true)]
    public bool Anywhere { get; set; } = true;

    [Category("Misc.")]
    [DisplayName("Armed and Dangerous")]
    [Description("Plays Armed and Dangerous, the Arm-Eye's boss theme from Eye of God. \n\n Victory theme: Contestant Eliminated")]
    [DefaultValue(true)]
    public bool ArmedAndDangerous { get; set; } = true;

    [Category("Misc.")]
    [DisplayName("Death Sentence")]
    [Description("Plays Death Sentence, Satan's boss theme from The Lamplighter.\n\nNo victory theme, only Death.")]
    [DefaultValue(true)]
    public bool DeathSentence { get; set; } = true;
}
