using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using System;


namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director{
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;
        private int speed = 0;
        private int score = 0;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService. Construye una nueva instancia de Director usando
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService){
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast. Inicia el juego ejecutando el ciclo principal del juego para el elenco dado
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast){
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// Obtiene la entrada direccional del teclado y la aplica al robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast){
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = _keyboardService.GetDirection();
            robot.SetVelocity(velocity);

            
            /// create the artifacts
            Random random = new Random();
            
            int x = random.Next(-1, 60);
            speed = random.Next(1, 10);
            Point position = new Point(x, 0);
            position = position.Scale(15);

            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            Color color = new Color(r, g, b);
            int createArtifact = random.Next(0, 30);
            if(createArtifact == 2){
                Artifact artifact = new Artifact();
                artifact.SetText("0");
                artifact.SetFontSize(30);
                artifact.SetColor(color);
                cast.AddActor("artifacts", artifact);
                artifact.SetPosition(position);
                artifact.SetVelocity(new Point(0, speed));
                artifact.SetValue(-10);
            } else if(createArtifact == 5){
                Artifact artifact = new Artifact();
                artifact.SetText("*");
                artifact.SetFontSize(30);
                artifact.SetColor(color);
                cast.AddActor("artifacts", artifact);
                artifact.SetPosition(position);
                artifact.SetVelocity(new Point(0, speed));
                artifact.SetValue(10);
            }
            
            

        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// Actualiza la posición del robot y resuelve cualquier colisión con artefactos 
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast){
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> artifacts = cast.GetActors("artifacts");

            banner.SetText("Score: ");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            robot.MoveNext(maxX, maxY);
            
            banner.SetText("Score: " + score.ToString());
            foreach (Actor actor in artifacts){
                Artifact artifact = (Artifact) actor;
                artifact.MoveNext(maxX, maxY);
                if (robot.GetPointY() < actor.GetPointY() + 16 && robot.GetPointX() == actor.GetPointX()){
                    score = score + artifact.GetValue();
                    Point PositionFinish = new Point(0,0);
                    artifact.SetVelocity(PositionFinish);
                    PositionFinish = new Point(-30, -1);
                    artifact.SetPosition (PositionFinish);
                }
        
                if (artifact.GetPointY() + 10 > 600){
                    Point PositionFinish = new Point(0,0);
                    artifact.SetVelocity(PositionFinish);
                    PositionFinish = new Point(-2, 0);
                    artifact.SetPosition (PositionFinish);
                    Color color = new Color(0, 0, 0);
                    artifact.SetColor(color);
                }  
                
            } 
        }

        /// <summary>
        /// Draws the actors on the screen. Dibuja los actores en la pantalla
        /// Dibuja a los actores en la pantalla.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast){
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

    }
}