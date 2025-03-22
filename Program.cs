using System;
using PlayerHelpers;

Pack firstPack = new Pack(10, 8, 4);
Console.WriteLine($"Pack Attributes | Item Limit: {firstPack.BagItemCapacity}, Weight: {firstPack.BagWeightCapacity}, Volume: {firstPack.BagVolumeCapacity}");

SwordItem sword = new SwordItem();
Console.WriteLine($"Sword Weight: {sword.ItemWeight}, Sword Volume: {sword.ItemVolume}");

firstPack.PackItem(sword);
firstPack.PackItem(new ArrowItem());

firstPack.PackItems(new ArrowItem(), new ArrowItem(), new ArrowItem(), new SwordItem());

Console.ReadLine();