using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

	public GameObject[,] mazeBlocks;

	public Material brick;
	
	public GameObject floor;

	private int[,] maze;

	private Stack<Coordinate> visited;

	public int length;
	public int height;

	public Coordinate start;

	public Coordinate finish;
	

	void Start() {

		visited = new Stack<Coordinate>();

		maze = new int[height, length];

		start = new Coordinate(1, 1);

		finish = new Coordinate(length-1, height-1);
		
		mazeBlocks = new GameObject[height, length];

		generateMaze(start);
	}

	void Update() {
	
	}

	private void generateMaze(Coordinate start) {

		maze[start.x, start.y] = 1;

		int x = start.x;
		int y = start.y;

		Coordinate coordinate = new Coordinate(x, y);
		visited.Push(coordinate);
		int[] neighbors;
		int count = 0;
		int choice;

		while (visited.Count != 0) {
			count = 0;
			neighbors = new int[4];
			// up
			if (y > 2 && maze[x, y - 2] == 0) {
				neighbors[0] = 1;
				count++;
			}
			// down
			if (y < this.height - 2 && maze[x, y + 2] == 0) {
				neighbors[1] = 1;
				count++;
			}
			// left
			if (x > 2 && maze[x - 2, y] == 0) {
				neighbors[2] = 1;
				count++;
			}
			// right
			if (x < this.length - 2 && maze[x + 2, y] == 0) {
				neighbors[3] = 1;
				count++;
			}
			if(count > 0) {
				do {
					choice = Random.Range(0, 4);
					if(neighbors[choice] == 1) {
						if(choice == 0) {
							maze[x, y-1] = 1;
							maze[x, y-2] = 1;
							coordinate = new Coordinate(x, y-2);
							visited.Push(coordinate);
							y = y-2;
						} else if (choice == 1) {
							maze[x, y+1] = 1;
							maze[x, y+2] = 1;
							coordinate = new Coordinate(x, y+2);
							visited.Push(coordinate);
							y = y+2;
						} else if (choice == 2) {
							maze[x-1, y] = 1;
							maze[x-2, y] = 1;
							coordinate = new Coordinate(x-2, y);
							visited.Push(coordinate);
							x = x-2;
						} else if(choice == 3) {
							maze[x+1, y] = 1;
							maze[x+2, y] = 1;
							coordinate = new Coordinate(x+2, y);
							visited.Push(coordinate);
							x = x+2;
						}
					}
				} while(neighbors[choice] != 1);
				
			} else {
				Coordinate temp = visited.Pop();
				x = temp.x;
				y = temp.y;
			}

		}

		for (int i=0; i<height; i++) {
			for (int j=0; j<length; j++) {
				if (maze[i, j] == 0) {
					mazeBlocks[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
					mazeBlocks[i, j].transform.parent = transform;
					mazeBlocks[i, j].name = "MazeBlock (" + i + ", " + j + ")";
					mazeBlocks[i, j].transform.position = new Vector3((float) (j+0.5), (float) 0.5, (float) (-1*i-0.5));
					mazeBlocks[i, j].renderer.material = brick;
				}
			}
		}
	}

	public int[,] getMaze() {
		return maze;
	}

}
