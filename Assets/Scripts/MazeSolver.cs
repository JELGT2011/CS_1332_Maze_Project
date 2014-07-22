using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeSolver : MonoBehaviour {

	public GameObject mazeObject;

	int length;
	int height;

	int[,] maze;

	int[,] visited;

	private Coordinate start;

	private Coordinate finish;

	private Queue<Coordinate> moves;

	private Coordinate next;

	bool trigger;

	Vector3 startPosition;

	bool moving;

	float weight;

	float liftSpeed;

	public Vector3 newPosition;

	void Start() {

		trigger = false;

		moving = false;

		visited = new int[length, height];

		weight = 0;

		liftSpeed = 10;

		newPosition = new Vector3();

		length = mazeObject.GetComponent<Maze>().length;
		height = mazeObject.GetComponent<Maze>().height;

		visited = new int[length, height];

		maze = mazeObject.GetComponent<Maze>().getMaze();

		start = mazeObject.GetComponent<Maze>().start;
		finish = mazeObject.GetComponent<Maze>().finish;

		solveBFS(start, finish);

		next = moves.Dequeue();

	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			transform.position.Set((float) (next.x+0.5), (float) (0),(float) (-1*next.y-0.5));
		}
		while (Input.GetKeyDown (KeyCode.Space));

		if (moves.Count != 0 ) {
			next = moves.Dequeue();
		}

	}

	private void solveBFS(Coordinate arg0, Coordinate arg1) {
		Coordinate current = arg0;
		Stack<Coordinate> backstack = new Stack<Coordinate>();
		moves = new Queue<Coordinate>();
		visited[arg0.x, arg0.y] = 1;
		int x = arg0.x;
		int y = arg0.y;
		Coordinate c = new Coordinate(x, y);

		Stack<Coordinate> cells = new Stack<Coordinate>();

		cells.Push(c);
		moves.Enqueue(c);
		
		int[] neighbors;
		int count = 0;
		while (cells.Count != 0) {
			count = 0;
			neighbors = new int[4];
			// up
			if (y > 2 && visited[x, y - 2] == 0 && maze[x, y - 1] == 1) {
				neighbors[0] = 1;
				count++;
			}
			// down
			if (y < this.height - 2 && visited[x, y + 2] == 0 && maze[x, y + 1] == 1) {
				neighbors[1] = 1;
				count++;
			}
			// left
			if (x > 2 && visited[x - 2, y] == 0 && maze[x - 1, y] == 1) {
				neighbors[2] = 1;
				count++;
			}
			// right
			if (x < this.length - 2 && visited[x + 2, y] == 0 && maze[x + 1, y] == 1) {
				neighbors[3] = 1;
				count++;
			}
			
			if (count > 0) {
				if (neighbors[3] == 1) {
					// visited[x] = 1;
					visited[x + 2, y] = 1;
					c = new Coordinate(x + 2, y);
					cells.Push(c);
					moves.Enqueue(c);
					x = x + 2;
				} else if (neighbors[1] == 1) {
					visited[x, y + 2] = 1;
					c = new Coordinate(x, y + 2);
					cells.Push(c);
					moves.Enqueue(c);
					y = y + 2;
				} else if (neighbors[0] == 1) {
					visited[x, y - 2] = 1;
					c = new Coordinate(x, y - 2);
					cells.Push(c);
					moves.Enqueue(c);
					y = y - 2;
				} else if (neighbors[2] == 1) {
					visited[x - 2, y] = 1;
					c = new Coordinate(x - 2, y);
					cells.Push(c);
					moves.Enqueue(c);
				} 
				if(x == length-2 && y == height-2) {
					return;
				}
			} 
		}
	}

}
