#pragma strict

var cell:GameObject;

private var unvisitedList:Array;

private var backStack:Stack;

function Start () {

  Instantiate(cell, Vector3(0, 0, 0));

  // for each cell in the maze, add to "unvisited list"
  // mark start as current, and remove from unvisitedList

  // while (!unvisitedList.isEmpty()) {
  //   if (unvisitedList.contains(current.left) || unvisitedList.contains(current.right)
  //       || unvisitedList.contains(current.front) || unvisitedList.contains(current.back)) {
  //     // randomly choose one of the unvisited neighbours
  //     backStack.push(current);
  //     // remove wall between current and chosen neighbour cell
  //     // current = // chosen neighbour cell
  //   } else if (!backStack.isEmpty()) {
  //     current = backStack.pop();
  //   } else {
  //     // pick a random unvisited cell, make it the current cell and mark it as visited
  //   }
  // }

  // for each cell in the maze
  // instantiate that cell

}

function Update () {

}
