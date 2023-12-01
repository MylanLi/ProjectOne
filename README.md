Hello, I'm learning more about programming by playing with Monogame.

And also to get used to using git as well as trying to add this to my routine.

Current Goal:
- Clean up the code

Documenting Progress:

Basics of monogame in 2D

- Main thing has been how to work with objects, which sort of includes sprites. 
- Sprites can be a simple texture, which can be drawn onto the screen like stamping shapes in paint. Needs other logic to tie them to information like coordinates, which can be either a whole bunch of them with one object, or a single object associated with a single sprite.
- Loading is taking a png or image file and associating it to a variable
- Draw is how the textures are stamped on the screen. AFAIK, its tied to the spritebatch.Draw funciton which can be called in the main Game.cs file, or by passing the spritebatch variable to another class to call it there as part of their "Draw" function
  - The draw function in the main Game.cs file is what the engine uses so I believe it has to be there
- Update is for logic. Do a similar thing with making update functions in classes that are all nested into the main file.

Sprites

- Create classes to contain information about what the texture is meant to represent, which I have been calling sprites. Maybe need to find a better name, since what I've been thinking of as textures because of the syntax are actually sprites, so I need a new way of calling the image + game data. Or just leave it.
  - Some quick googling came up with doodad for non-interactable stuff, and props for interactable. I think Unity has the term GameObject, but maybe a bit clunky. GameObj?
- Animating them seems to be straightforward enough, as long as the sprite is tied to an object with its own draw function.
  - Is there a way to do this calculation and pass on a value or something to the object, rather than having every object do its own calculation?

Controllers

- I've been using this term to refer to the class which is like a middle-man/manager for grouping together the discrete sprite objects and their functionality.