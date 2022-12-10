using Unit05.Game.Casting;
using Unit05.Game.Services;
using System.Collections.Generic;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the Cycle.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the Cycle head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction1 = new Point(0, - Constants.CELL_SIZE);
        private Point _direction2 = new Point(0, - Constants.CELL_SIZE);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            
            // left
            if (_keyboardService.IsKeyDown("a")){
                _direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("d")){
                _direction1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("w") ){
                _direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("s")){
                _direction1 = new Point(0, Constants.CELL_SIZE);
            }

            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycles");
            cycle1.TurnHead(_direction1);


            // left
            if (_keyboardService.IsKeyDown("j"))
            {
                _direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("l"))
            {
                _direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("i"))
            {
                _direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("k"))
            {
                _direction2 = new Point(0, Constants.CELL_SIZE);
            }

            List<Actor> cycles = cast.GetActors("cycles");
            Cycle cycle2 = (Cycle)cycles[1];
            cycle2.TurnHead(_direction2);

        }
    }
}