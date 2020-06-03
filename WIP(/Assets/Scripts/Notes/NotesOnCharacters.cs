using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////////////////////////////////Character notes/////////////////////////////////////////////////////////
/* Characters have health, attack, defense, and speed.
 * Characters run in groups.
 * Groups contain one type of character.
 * Groups where the characters have a higher speed will attack first.
 * The whole group will attack per turn.
 * Characters will roll attack between lower an upper bounds displayed on "card" (e.g 2-4 = 2,3, or 4).
 * Attack roll will be contested by the lowest number of the defending characters defense, the higher value wins. (e.g roll of 3 vs. 2-4 def(2), 3 wins for attack).
 * The defending group will send characters to defend the number of hits from the attack rolls.
 * Characters will roll defense between lower and upper bounds displayed on "card" (e.g. 1-4 = 1,2,3, or 4).
 * The defense roll will be contested by the highest number of the attacking characters attack, the higher value wins. (e.g roll of 3 vs. 1-4 atk(4), 4 wins for attack).
 * If attack roll fails, the attack will miss.
 * If attack roll succeeds and defense roll succeeds, the defender blocks the attack.
 * If attack roll succeeds and defense roll fails, the attack lands.
 * If the attack lands, subtract 1 from the defending characters health.
 * When a character dies, subtract 1 from the character count from the total characters in a group.
 * After all characters in a group attack, switch turns.
 * If all characters in the defense group die, the attack is successful and the attack group advances to the tower.
 * If all characters in the attack group die, the attack has failed an the attacking group is destroyed.
     
     
     
     
     
     
     */