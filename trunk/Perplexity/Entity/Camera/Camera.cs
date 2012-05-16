using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public class Camera
    {
        #region Enum

        #endregion


        #region Field

        //Protected
        private Matrix view;
        private Matrix projection;
        private Vector3 position = Vector3.Zero;
        private Quaternion rotation = Quaternion.Identity;
        private float fov = (float)(Math.PI / 4.0);
        private float aspectRatio = 4f / 3f;
        private float nearPlane = 1.0f;
        private float farPlane = 1000.0f;
        private Vector3 direction = Vector3.Forward;
        private BoundingFrustum frustum;
        private Rectangle boundingRec;
        private bool useBoundingRec = false;

        #endregion


        #region Property

        public Matrix View
        {
            get { return view; }
        }
        public Matrix Projection
        {
            get { return projection; }
        }
        public Vector3 Position
        {
            get { return position; }

            set
            {
                if (useBoundingRec)
                {
                    Point camPosition2D = new Point((int)value.X * -1, (int)value.Y * -1);
                    if (boundingRec.Contains(camPosition2D))
                    {
                        position = value;
                    }
                    else
                    {
                        Vector3 newPosition = value;
                        if (camPosition2D.X < boundingRec.X)
                            newPosition.X = boundingRec.X;
                        else if (camPosition2D.X > (boundingRec.X + boundingRec.Width))
                            newPosition.X = (boundingRec.X + boundingRec.Width) * -1;
                        if (camPosition2D.Y < boundingRec.Y)
                            newPosition.Y = boundingRec.Y;
                        else if (camPosition2D.Y > (boundingRec.Y + boundingRec.Height))
                            newPosition.Y = (boundingRec.Y + boundingRec.Height) * -1;

                        position = newPosition;
                    }
                }
                else
                {
                    position = value;
                }
            }
        }
        public Quaternion Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public float Fov
        {
            get { return fov; }
            set { fov = value; }
        }
        public float AspectRatio
        {
            get { return aspectRatio; }
            set { aspectRatio = value; }
        }
        public float NearPlane
        {
            get { return nearPlane; }
            set { nearPlane = value; }
        }
        public float FarPlane
        {
            get { return farPlane; }
            set { farPlane = value; }
        }
        public Vector3 Direction
        {
            get { return direction; }
        }
        public BoundingFrustum Frustum
        {
            get { return frustum; }
        }
        public Rectangle BoundingRec
        {
            get { return boundingRec; }
            set { boundingRec = value; }
        }
        public bool UseBoundingRec
        {
            get { return useBoundingRec; }
            set { useBoundingRec = value; }
        }

        #endregion


        #region Method

        public void LookAt(Vector3 target, Vector3 up)
        {
            view = Matrix.CreateLookAt(position, target, up);
            rotation = Quaternion.CreateFromRotationMatrix(Matrix.Invert(view));
            direction = target - position;
            direction.Normalize();
        }

        #endregion


        #region Event

        public void OnUpdate()
        {
            projection = Matrix.CreatePerspectiveFieldOfView(fov, aspectRatio, nearPlane, farPlane);
            Matrix matrix = Matrix.CreateFromQuaternion(rotation);
            matrix.Translation = position;
            view = Matrix.Invert(matrix);
            frustum = new BoundingFrustum(Matrix.Multiply(view, projection));
            direction = -view.Forward;
            direction.Normalize();

        }

        #endregion
    }
}
