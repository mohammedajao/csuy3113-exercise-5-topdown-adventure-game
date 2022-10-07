using System;

public static class Events {
    public static readonly Evt<Collectible> onPickup = new Evt<Collectible>();
    public static readonly Evt onDoorwayTriggerEnter = new Evt();
    public static readonly Evt<int> playerTakeDamage = new Evt<int>();
}