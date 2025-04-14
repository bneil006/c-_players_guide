using DND;

// Completed Events

// Not Happened
SessionEvents.AddEvent(
    dndEvent: "Acid Pool",
    location: "Underdark",
    player: "Party",
    text:
    "Kevin used dimension door to Clapper and himself to the other side of the acid bath in the underdark.\n" +
    "Matt uses polymorph to turn into a teradactial and move everyone else across.\n" +
    "Austins character, tells us all in character that we shouldn't rest or take our time, we find our selves\n" +
    "in the underdark and speed is the upmost importance.\n" +
    "Matt decides to stay in his polymorph form.");

SessionEvents.AddEvent(
    dndEvent: "Riccity Bridge",
    location: "Underdark", 
    player: "Party", 
    text: 
    "We travel single file down the tunnel, Austin, Kevin, Brandon, Astrid, Matt, Konner. \n" +
    "We reach a bearly hanging rope bridge after traveling a little ways.\n" +
    "The reveen is 50' wide and 60' deep.\n" +
    "Konner made a perception check. Rolled 2. Saw a ravine and a fucked up bridge.\n" +
    "Matt uses mending cantrip and mends the bridge sucessfully.\n" +
    "Konner crosses first. No issues. Austin Follows with a 9. No issues. Brandon with a 2. Bridge holds, No issues.\n" +
    "Kevin turns into a bird and flies across. Killa our deer rolled a Nat 1, then rerolled for a Nat 20. No issues.\n" +
    "Matt turns into Giant Eagle and carries Astrid across." +
    "Austin said to the party that, it feels like as long as the druid can polymorph, we should get through this no problem.\n" +
    "Astrid says we will blame the navigator for any problems encountered (Austin).\n" +
    "Austin asks Astrid which way we should go.\n" +
    "Astrid isn't backing down from Austins Challenge to essentially ");

//SessionEvents.AddEvent(
//    location: "Underdark",
//    player: "Party",
//    text:
//    "");

// Display Events
SessionEvents.GetEvents();
Console.WriteLine();
SessionEvents.GetLocationAndPlayer();