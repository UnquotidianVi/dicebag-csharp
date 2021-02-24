# dicebag-csharp
A C# port of [Dicebag](https://github.com/8bitskull/dicebag) by [8bitskull](https://github.com/8bitskull), originally in Lua for Defold.

Dicebag is an addon of probability functions designed specifically for games.
Inspired by this excellent blog post: https://www.redblobgames.com/articles/probability/damage-rolls.html

## Other Ports
[dicebag-godot](https://github.com/Yagich/dicebag-godot) by [Yagich](https://github.com/Yagich)

# Usage
After dropping the files to your project, you can access the proparility functions with the "Dicebag" namespace

## Dicebag.Dicebag (class)
Main Dicebag class hosting most of the propability functions.

### Dicebag.Dicebag.R (System.Random)
The random generator used by Dicebag. To set a seed for the generator, do the following:
```
Dicebag.Dicebag.R = new System.Random(seed);
```

### Dicebag.Dicebag.FlipCoin() (bool)
50% chance of returning either true or false

### Dicebag.Dicebag.RollDice() (int)
Roll one or multiple dices. Returns resulting roll value.
**PARAMETERS**
* `_numOfDice` (int) optional | specify how many dices to roll
* `_numOfSides` (int) optional | specify the side count of each dice
* `_modifier` (int) optional | modifier added to the total roll

### Dicebag.Dicebag.RollSpecialDice() (int)
Roll one or more dice with advantage or disadvantage
**PARAMETERS**
* `_numOfDice` (int) required | specify how many dices to roll
* `_numOfResults` (int) required | specify how many of rolled dices will be in the final result
* `_advantage` (bool) optional | true = discriminate against low values / false = discriminate against high values
* `_numOfSides` (int) optional | specify the side count of each dice

### Dicebag.Dicebag.RollCustomDice() (int)
Roll a dice with custom sides
**PARAMETERS**
* `_customDice` (Dicebag.Dice.CustomDice) required | specify a custom dice to use
* `_numOfDice` (int) optional | specify how many dices to roll

### Dicebag.Dice.CustomDice (struct)
Custom dice containing an array of `Dicebag.Dice.DieSide`
**PARAMETERS**
* `_sides` (Dicebag.Dice.DieSide[]) required | array of Dicebag.Dice.DieSide to use for the Die

### Dicebag.Dice.DieSide (struct)
Custom DiceSide used for creating CustomDices
**PARAMETERS**
* `_weight` (float) required | weight is used to determine how likely it is to roll this DieSide
* `_value` (int) required | value of the DieSide given when rolled

### Dicebag.MarbleBag (class)
A bag of green (success) and red (fail) "marbles" that you can draw from.
**PARAMETERS**
* `_successCount` (int) required | number of green marbles
* `_failCount` (int) required | number of red marbles
* `_resetOnSuccess` (bool) required | true = refill the MarbleBag when green marble is picked

### Dicebag.MarbleBag.DrawMarbleFromBag() (bool)
Draw a marble from marble bag. Returns true if marble is green and false if marble is red.

### Didebag.MarbleBag.ResetBag() (void)
Reset marbles in the bag

### Dicebag.RotatingTable (class)
A rollable table where entries are removed as they are rolled
**PARAMETERS**
* `_tableItems` (Dicebag.RotaingTableItem[]) required | array of RotatingTableItems

### Dicebag.RotatingTable.RotateTable() (int)
Roll a value from a rollable table. Returns the value specified in the table.

### Dicebag.RotatingTable.ResetTable() (void)
Reset table's items to the original ones

### Dicebag.RotatingTableItem (struct)
**PARAMETERS**
* `_weight` (float) required | value used to determine how likely it is to roll this item
* `_value` (int) required | value given when rolled
* `_resetOnRoll` (bool) required | true = reset the table's items when this item is rolled