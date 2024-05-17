using OpenGl.Graphics;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenTK.Graphics.OpenGL.GL;




namespace OpenGl
{
    internal class GameObject
    {

        static float X = .525731112119133606f;
        static float Z = .850650808352039932f;



        public List<Vector3> gameVerts;
        public List<Vector2> gameGraphic = new List<Vector2>();
        public List<uint> gameInd;
        int type;

        VAO gameVAO;
        VBO gameVertexVBO;
        VBO gameGraphicVBO;
        IBO gameIBO;

        Texture texture;

        // 0 - икосаедр, 1 - куб
        public GameObject(int ttype,String path)
        {
            type=ttype;
            if(ttype==0)
            {
                MakeIco();
                Random rnd = new Random();
                objectSize = rnd.Next(3, 5) / 10f;
                objectMove = rnd.Next(typeOfMove.Count-1);
                position = new Vector3(rnd.Next(-9, 10)-1, rnd.Next(-9, 10)+1, 0);
            }
            else
            {
                MakeCube();
                position = new Vector3(0, 0, -5);
            }
            
            BuildObject(path);

            
        }

        public void MakeIco()
        {
            gameVerts = new List<Vector3>()
            {
            new Vector3(0f, 1f, 0f),
new Vector3(0.281733f, 0.959493f, 0f),
new Vector3(0.27032f, 0.959493f, 0.0793732f),
new Vector3(0.237009f, 0.959493f, 0.152316f),
new Vector3(0.184496f, 0.959493f, 0.212919f),
new Vector3(0.117036f, 0.959493f, 0.256273f),
new Vector3(0.0400947f, 0.959493f, 0.278865f),
new Vector3(-0.0400947f, 0.959493f, 0.278865f),
new Vector3(-0.117036f, 0.959493f, 0.256273f),
new Vector3(-0.184496f, 0.959493f, 0.212919f),
new Vector3(-0.237009f, 0.959493f, 0.152316f),
new Vector3(-0.27032f, 0.959493f, 0.0793732f),
new Vector3(-0.281733f, 0.959493f, 1.59617e-16f),
new Vector3(-0.27032f, 0.959493f, -0.0793732f),
new Vector3(-0.237009f, 0.959493f, -0.152316f),
new Vector3(-0.184496f, 0.959493f, -0.212919f),
new Vector3(-0.117036f, 0.959493f, -0.256273f),
new Vector3(-0.0400947f, 0.959493f, -0.278865f),
new Vector3(0.0400947f, 0.959493f, -0.278865f),
new Vector3(0.117036f, 0.959493f, -0.256273f),
new Vector3(0.184496f, 0.959493f, -0.212919f),
new Vector3(0.237009f, 0.959493f, -0.152316f),
new Vector3(0.27032f, 0.959493f, -0.0793732f),
new Vector3(0.540641f, 0.841254f, 0f),
new Vector3(0.518741f, 0.841254f, 0.152316f),
new Vector3(0.454816f, 0.841254f, 0.292292f),
new Vector3(0.354044f, 0.841254f, 0.408589f),
new Vector3(0.22459f, 0.841254f, 0.491784f),
new Vector3(0.0769412f, 0.841254f, 0.535138f),
new Vector3(-0.0769412f, 0.841254f, 0.535138f),
new Vector3(-0.22459f, 0.841254f, 0.491784f),
new Vector3(-0.354044f, 0.841254f, 0.408589f),
new Vector3(-0.454816f, 0.841254f, 0.292292f),
new Vector3(-0.518741f, 0.841254f, 0.152316f),
new Vector3(-0.540641f, 0.841254f, 3.06302e-16f),
new Vector3(-0.518741f, 0.841254f, -0.152316f),
new Vector3(-0.454816f, 0.841254f, -0.292292f),
new Vector3(-0.354044f, 0.841254f, -0.408589f),
new Vector3(-0.22459f, 0.841254f, -0.491784f),
new Vector3(-0.0769412f, 0.841254f, -0.535138f),
new Vector3(0.0769412f, 0.841254f, -0.535138f),
new Vector3(0.22459f, 0.841254f, -0.491784f),
new Vector3(0.354044f, 0.841254f, -0.408589f),
new Vector3(0.454816f, 0.841254f, -0.292292f),
new Vector3(0.518741f, 0.841254f, -0.152316f),
new Vector3(0.75575f, 0.654861f, 0f),
new Vector3(0.725136f, 0.654861f, 0.212919f),
new Vector3(0.635777f, 0.654861f, 0.408589f),
new Vector3(0.494911f, 0.654861f, 0.571157f),
new Vector3(0.31395f, 0.654861f, 0.687454f),
new Vector3(0.107554f, 0.654861f, 0.748057f),
new Vector3(-0.107554f, 0.654861f, 0.748057f),
new Vector3(-0.31395f, 0.654861f, 0.687454f),
new Vector3(-0.494911f, 0.654861f, 0.571157f),
new Vector3(-0.635777f, 0.654861f, 0.408589f),
new Vector3(-0.725136f, 0.654861f, 0.212919f),
new Vector3(-0.75575f, 0.654861f, 4.28173e-16f),
new Vector3(-0.725136f, 0.654861f, -0.212919f),
new Vector3(-0.635777f, 0.654861f, -0.408589f),
new Vector3(-0.494911f, 0.654861f, -0.571157f),
new Vector3(-0.31395f, 0.654861f, -0.687454f),
new Vector3(-0.107554f, 0.654861f, -0.748057f),
new Vector3(0.107554f, 0.654861f, -0.748057f),
new Vector3(0.31395f, 0.654861f, -0.687454f),
new Vector3(0.494911f, 0.654861f, -0.571157f),
new Vector3(0.635777f, 0.654861f, -0.408589f),
new Vector3(0.725136f, 0.654861f, -0.212919f),
new Vector3(0.909632f, 0.415415f, 0f),
new Vector3(0.872786f, 0.415415f, 0.256273f),
new Vector3(0.765231f, 0.415415f, 0.491784f),
new Vector3(0.595682f, 0.415415f, 0.687454f),
new Vector3(0.377875f, 0.415415f, 0.82743f),
new Vector3(0.129454f, 0.415415f, 0.900373f),
new Vector3(-0.129454f, 0.415415f, 0.900373f),
new Vector3(-0.377875f, 0.415415f, 0.82743f),
new Vector3(-0.595682f, 0.415415f, 0.687454f),
new Vector3(-0.765231f, 0.415415f, 0.491784f),
new Vector3(-0.872786f, 0.415415f, 0.256273f),
new Vector3(-0.909632f, 0.415415f, 5.15356e-16f),
new Vector3(-0.872786f, 0.415415f, -0.256273f),
new Vector3(-0.765231f, 0.415415f, -0.491784f),
new Vector3(-0.595682f, 0.415415f, -0.687454f),
new Vector3(-0.377875f, 0.415415f, -0.82743f),
new Vector3(-0.129454f, 0.415415f, -0.900373f),
new Vector3(0.129454f, 0.415415f, -0.900373f),
new Vector3(0.377875f, 0.415415f, -0.82743f),
new Vector3(0.595682f, 0.415415f, -0.687454f),
new Vector3(0.765231f, 0.415415f, -0.491784f),
new Vector3(0.872786f, 0.415415f, -0.256273f),
new Vector3(0.989821f, 0.142315f, 0f),
new Vector3(0.949727f, 0.142315f, 0.278865f),
new Vector3(0.832691f, 0.142315f, 0.535138f),
new Vector3(0.648195f, 0.142315f, 0.748057f),
new Vector3(0.411187f, 0.142315f, 0.900373f),
new Vector3(0.140866f, 0.142315f, 0.979746f),
new Vector3(-0.140866f, 0.142315f, 0.979746f),
new Vector3(-0.411187f, 0.142315f, 0.900373f),
new Vector3(-0.648195f, 0.142315f, 0.748057f),
new Vector3(-0.832691f, 0.142315f, 0.535138f),
new Vector3(-0.949727f, 0.142315f, 0.278865f),
new Vector3(-0.989821f, 0.142315f, 5.60787e-16f),
new Vector3(-0.949727f, 0.142315f, -0.278865f),
new Vector3(-0.832691f, 0.142315f, -0.535138f),
new Vector3(-0.648195f, 0.142315f, -0.748057f),
new Vector3(-0.411187f, 0.142315f, -0.900373f),
new Vector3(-0.140866f, 0.142315f, -0.979746f),
new Vector3(0.140866f, 0.142315f, -0.979746f),
new Vector3(0.411187f, 0.142315f, -0.900373f),
new Vector3(0.648195f, 0.142315f, -0.748057f),
new Vector3(0.832691f, 0.142315f, -0.535138f),
new Vector3(0.949727f, 0.142315f, -0.278865f),
new Vector3(0.989821f, -0.142315f, 0f),
new Vector3(0.949727f, -0.142315f, 0.278865f),
new Vector3(0.832691f, -0.142315f, 0.535138f),
new Vector3(0.648195f, -0.142315f, 0.748057f),
new Vector3(0.411187f, -0.142315f, 0.900373f),
new Vector3(0.140866f, -0.142315f, 0.979746f),
new Vector3(-0.140866f, -0.142315f, 0.979746f),
new Vector3(-0.411187f, -0.142315f, 0.900373f),
new Vector3(-0.648195f, -0.142315f, 0.748057f),
new Vector3(-0.832691f, -0.142315f, 0.535138f),
new Vector3(-0.949727f, -0.142315f, 0.278865f),
new Vector3(-0.989821f, -0.142315f, 5.60787e-16f),
new Vector3(-0.949727f, -0.142315f, -0.278865f),
new Vector3(-0.832691f, -0.142315f, -0.535138f),
new Vector3(-0.648195f, -0.142315f, -0.748057f),
new Vector3(-0.411187f, -0.142315f, -0.900373f),
new Vector3(-0.140866f, -0.142315f, -0.979746f),
new Vector3(0.140866f, -0.142315f, -0.979746f),
new Vector3(0.411187f, -0.142315f, -0.900373f),
new Vector3(0.648195f, -0.142315f, -0.748057f),
new Vector3(0.832691f, -0.142315f, -0.535138f),
new Vector3(0.949727f, -0.142315f, -0.278865f),
new Vector3(0.909632f, -0.415415f, 0f),
new Vector3(0.872786f, -0.415415f, 0.256273f),
new Vector3(0.765231f, -0.415415f, 0.491784f),
new Vector3(0.595682f, -0.415415f, 0.687454f),
new Vector3(0.377875f, -0.415415f, 0.82743f),
new Vector3(0.129454f, -0.415415f, 0.900373f),
new Vector3(-0.129454f, -0.415415f, 0.900373f),
new Vector3(-0.377875f, -0.415415f, 0.82743f),
new Vector3(-0.595682f, -0.415415f, 0.687454f),
new Vector3(-0.765231f, -0.415415f, 0.491784f),
new Vector3(-0.872786f, -0.415415f, 0.256273f),
new Vector3(-0.909632f, -0.415415f, 5.15356e-16f),
new Vector3(-0.872786f, -0.415415f, -0.256273f),
new Vector3(-0.765231f, -0.415415f, -0.491784f),
new Vector3(-0.595682f, -0.415415f, -0.687454f),
new Vector3(-0.377875f, -0.415415f, -0.82743f),
new Vector3(-0.129454f, -0.415415f, -0.900373f),
new Vector3(0.129454f, -0.415415f, -0.900373f),
new Vector3(0.377875f, -0.415415f, -0.82743f),
new Vector3(0.595682f, -0.415415f, -0.687454f),
new Vector3(0.765231f, -0.415415f, -0.491784f),
new Vector3(0.872786f, -0.415415f, -0.256273f),
new Vector3(0.75575f, -0.654861f, 0f),
new Vector3(0.725136f, -0.654861f, 0.212919f),
new Vector3(0.635777f, -0.654861f, 0.408589f),
new Vector3(0.494911f, -0.654861f, 0.571157f),
new Vector3(0.31395f, -0.654861f, 0.687454f),
new Vector3(0.107554f, -0.654861f, 0.748057f),
new Vector3(-0.107554f, -0.654861f, 0.748057f),
new Vector3(-0.31395f, -0.654861f, 0.687454f),
new Vector3(-0.494911f, -0.654861f, 0.571157f),
new Vector3(-0.635777f, -0.654861f, 0.408589f),
new Vector3(-0.725136f, -0.654861f, 0.212919f),
new Vector3(-0.75575f, -0.654861f, 4.28173e-16f),
new Vector3(-0.725136f, -0.654861f, -0.212919f),
new Vector3(-0.635777f, -0.654861f, -0.408589f),
new Vector3(-0.494911f, -0.654861f, -0.571157f),
new Vector3(-0.31395f, -0.654861f, -0.687454f),
new Vector3(-0.107554f, -0.654861f, -0.748057f),
new Vector3(0.107554f, -0.654861f, -0.748057f),
new Vector3(0.31395f, -0.654861f, -0.687454f),
new Vector3(0.494911f, -0.654861f, -0.571157f),
new Vector3(0.635777f, -0.654861f, -0.408589f),
new Vector3(0.725136f, -0.654861f, -0.212919f),
new Vector3(0.540641f, -0.841254f, 0f),
new Vector3(0.518741f, -0.841254f, 0.152316f),
new Vector3(0.454816f, -0.841254f, 0.292292f),
new Vector3(0.354044f, -0.841254f, 0.408589f),
new Vector3(0.22459f, -0.841254f, 0.491784f),
new Vector3(0.0769412f, -0.841254f, 0.535138f),
new Vector3(-0.0769412f, -0.841254f, 0.535138f),
new Vector3(-0.22459f, -0.841254f, 0.491784f),
new Vector3(-0.354044f, -0.841254f, 0.408589f),
new Vector3(-0.454816f, -0.841254f, 0.292292f),
new Vector3(-0.518741f, -0.841254f, 0.152316f),
new Vector3(-0.540641f, -0.841254f, 3.06302e-16f),
new Vector3(-0.518741f, -0.841254f, -0.152316f),
new Vector3(-0.454816f, -0.841254f, -0.292292f),
new Vector3(-0.354044f, -0.841254f, -0.408589f),
new Vector3(-0.22459f, -0.841254f, -0.491784f),
new Vector3(-0.0769412f, -0.841254f, -0.535138f),
new Vector3(0.0769412f, -0.841254f, -0.535138f),
new Vector3(0.22459f, -0.841254f, -0.491784f),
new Vector3(0.354044f, -0.841254f, -0.408589f),
new Vector3(0.454816f, -0.841254f, -0.292292f),
new Vector3(0.518741f, -0.841254f, -0.152316f),
new Vector3(0.281733f, -0.959493f, 0f),
new Vector3(0.27032f, -0.959493f, 0.0793732f),
new Vector3(0.237009f, -0.959493f, 0.152316f),
new Vector3(0.184496f, -0.959493f, 0.212919f),
new Vector3(0.117036f, -0.959493f, 0.256273f),
new Vector3(0.0400947f, -0.959493f, 0.278865f),
new Vector3(-0.0400947f, -0.959493f, 0.278865f),
new Vector3(-0.117036f, -0.959493f, 0.256273f),
new Vector3(-0.184496f, -0.959493f, 0.212919f),
new Vector3(-0.237009f, -0.959493f, 0.152316f),
new Vector3(-0.27032f, -0.959493f, 0.0793732f),
new Vector3(-0.281733f, -0.959493f, 1.59617e-16f),
new Vector3(-0.27032f, -0.959493f, -0.0793732f),
new Vector3(-0.237009f, -0.959493f, -0.152316f),
new Vector3(-0.184496f, -0.959493f, -0.212919f),
new Vector3(-0.117036f, -0.959493f, -0.256273f),
new Vector3(-0.0400947f, -0.959493f, -0.278865f),
new Vector3(0.0400947f, -0.959493f, -0.278865f),
new Vector3(0.117036f, -0.959493f, -0.256273f),
new Vector3(0.184496f, -0.959493f, -0.212919f),
new Vector3(0.237009f, -0.959493f, -0.152316f),
new Vector3(0.27032f, -0.959493f, -0.0793732f),
new Vector3(0f, -1f, 0f)
            };
            gameInd = new List<uint>()
            {
                0,2,1,0,3,2,0,4,3,0,5,4,0,6,5,0,7,6,0,8,7,0,9,8,0,10,9,0,11,10,0,12,11,0,13,12,0,14,13,0,15,14,0,16,15,0,17,16,0,18,17,0,19,18,0,20,19,0,21,20,0,22,21,0,1,22,1,2,24,1,24,23,2,3,25,2,25,24,3,4,26,3,26,25,4,5,27,4,27,26,5,6,28,5,28,27,6,7,29,6,29,28,7,8,30,7,30,29,8,9,31,8,31,30,9,10,32,9,32,31,10,11,33,10,33,32,11,12,34,11,34,33,12,13,35,12,35,34,13,14,36,13,36,35,14,15,37,14,37,36,15,16,38,15,38,37,16,17,39,16,39,38,17,18,40,17,40,39,18,19,41,18,41,40,19,20,42,19,42,41,20,21,43,20,43,42,21,22,44,21,44,43,22,1,23,22,23,44,23,24,46,23,46,45,24,25,47,24,47,46,25,26,48,25,48,47,26,27,49,26,49,48,27,28,50,27,50,49,28,29,51,28,51,50,29,30,52,29,52,51,30,31,53,30,53,52,31,32,54,31,54,53,32,33,55,32,55,54,33,34,56,33,56,55,34,35,57,34,57,56,35,36,58,35,58,57,36,37,59,36,59,58,37,38,60,37,60,59,38,39,61,38,61,60,39,40,62,39,62,61,40,41,63,40,63,62,41,42,64,41,64,63,42,43,65,42,65,64,43,44,66,43,66,65,44,23,45,44,45,66,45,46,68,45,68,67,46,47,69,46,69,68,47,48,70,47,70,69,48,49,71,48,71,70,49,50,72,49,72,71,50,51,73,50,73,72,51,52,74,51,74,73,52,53,75,52,75,74,53,54,76,53,76,75,54,55,77,54,77,76,55,56,78,55,78,77,56,57,79,56,79,78,57,58,80,57,80,79,58,59,81,58,81,80,59,60,82,59,82,81,60,61,83,60,83,82,61,62,84,61,84,83,62,63,85,62,85,84,63,64,86,63,86,85,64,65,87,64,87,86,65,66,88,65,88,87,66,45,67,66,67,88,67,68,90,67,90,89,68,69,91,68,91,90,69,70,92,69,92,91,70,71,93,70,93,92,71,72,94,71,94,93,72,73,95,72,95,94,73,74,96,73,96,95,74,75,97,74,97,96,75,76,98,75,98,97,76,77,99,76,99,98,77,78,100,77,100,99,78,79,101,78,101,100,79,80,102,79,102,101,80,81,103,80,103,102,81,82,104,81,104,103,82,83,105,82,105,104,83,84,106,83,106,105,84,85,107,84,107,106,85,86,108,85,108,107,86,87,109,86,109,108,87,88,110,87,110,109,88,67,89,88,89,110,89,90,112,89,112,111,90,91,113,90,113,112,91,92,114,91,114,113,92,93,115,92,115,114,93,94,116,93,116,115,94,95,117,94,117,116,95,96,118,95,118,117,96,97,119,96,119,118,97,98,120,97,120,119,98,99,121,98,121,120,99,100,122,99,122,121,100,101,123,100,123,122,101,102,124,101,124,123,102,103,125,102,125,124,103,104,126,103,126,125,104,105,127,104,127,126,105,106,128,105,128,127,106,107,129,106,129,128,107,108,130,107,130,129,108,109,131,108,131,130,109,110,132,109,132,131,110,89,111,110,111,132,111,112,134,111,134,133,112,113,135,112,135,134,113,114,136,113,136,135,114,115,137,114,137,136,115,116,138,115,138,137,116,117,139,116,139,138,117,118,140,117,140,139,118,119,141,118,141,140,119,120,142,119,142,141,120,121,143,120,143,142,121,122,144,121,144,143,122,123,145,122,145,144,123,124,146,123,146,145,124,125,147,124,147,146,125,126,148,125,148,147,126,127,149,126,149,148,127,128,150,127,150,149,128,129,151,128,151,150,129,130,152,129,152,151,130,131,153,130,153,152,131,132,154,131,154,153,132,111,133,132,133,154,133,134,156,133,156,155,134,135,157,134,157,156,135,136,158,135,158,157,136,137,159,136,159,158,137,138,160,137,160,159,138,139,161,138,161,160,139,140,162,139,162,161,140,141,163,140,163,162,141,142,164,141,164,163,142,143,165,142,165,164,143,144,166,143,166,165,144,145,167,144,167,166,145,146,168,145,168,167,146,147,169,146,169,168,147,148,170,147,170,169,148,149,171,148,171,170,149,150,172,149,172,171,150,151,173,150,173,172,151,152,174,151,174,173,152,153,175,152,175,174,153,154,176,153,176,175,154,133,155,154,155,176,155,156,178,155,178,177,156,157,179,156,179,178,157,158,180,157,180,179,158,159,181,158,181,180,159,160,182,159,182,181,160,161,183,160,183,182,161,162,184,161,184,183,162,163,185,162,185,184,163,164,186,163,186,185,164,165,187,164,187,186,165,166,188,165,188,187,166,167,189,166,189,188,167,168,190,167,190,189,168,169,191,168,191,190,169,170,192,169,192,191,170,171,193,170,193,192,171,172,194,171,194,193,172,173,195,172,195,194,173,174,196,173,196,195,174,175,197,174,197,196,175,176,198,175,198,197,176,155,177,176,177,198,177,178,200,177,200,199,178,179,201,178,201,200,179,180,202,179,202,201,180,181,203,180,203,202,181,182,204,181,204,203,182,183,205,182,205,204,183,184,206,183,206,205,184,185,207,184,207,206,185,186,208,185,208,207,186,187,209,186,209,208,187,188,210,187,210,209,188,189,211,188,211,210,189,190,212,189,212,211,190,191,213,190,213,212,191,192,214,191,214,213,192,193,215,192,215,214,193,194,216,193,216,215,194,195,217,194,217,216,195,196,218,195,218,217,196,197,219,196,219,218,197,198,220,197,220,219,198,177,199,198,199,220,221,199,200,221,200,201,221,201,202,221,202,203,221,203,204,221,204,205,221,205,206,221,206,207,221,207,208,221,208,209,221,209,210,221,210,211,221,211,212,221,212,213,221,213,214,221,214,215,221,215,216,221,216,217,221,217,218,221,218,219,221,219,220,221,220,199
            };
            for (int i = 0; i < gameVerts.Count; i++)
            {
                Vector3 n= gameVerts[i];
                n.Normalize();
                float u = (float)(MathHelper.Atan2(n.X, n.Z)/(2 * MathHelper.Pi) + 0.5f);
                float v = n.Y * 0.5f + 0.5f;
                gameGraphic.Add(new Vector2(u, v));
            }
        }

        public void MakeCube()
        {
            gameVerts = new List<Vector3>()
            {
            new Vector3(-30f, 30f, 0.30f), 
            new Vector3(30f, 30f, 0.30f), 
            new Vector3(30f, -30f, 0.30f), 
            new Vector3(-30f, -30f, 0.30f), 
            
            new Vector3(30f, 30f, 0.30f), 
            new Vector3(30f, 30f, -0.30f), 
            new Vector3(30f, -30f, -0.30f), 
            new Vector3(30f, -30f, 0.30f), 
            
            new Vector3(30f, 30f, -0.30f), 
            new Vector3(-30f, 30f, -0.30f), 
            new Vector3(-30f, -30f, -0.30f), 
            new Vector3(30f, -30f, -0.30f), 
            
            new Vector3(-30f, 30f, -0.30f),
            new Vector3(-30f, 30f, 0.30f),
            new Vector3(-30f, -30f, 0.30f),
            new Vector3(-30f, -30f, -0.30f),
            
            new Vector3(-30f, 30f, -0.30f),
            new Vector3(30f, 30f, -0.30f),
            new Vector3(30f, 30f, 0.30f),
            new Vector3(-30f, 30f, 0.30f),
            
            new Vector3(-30f, -30f, 0.30f), 
            new Vector3(30f, -30f, 0.30f), 
            new Vector3(30f, -30f, -0.30f), 
            new Vector3(-30f, -30f, -0.30f),
            };
            gameGraphic = new List<Vector2>()
            {
             new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),
            };

            gameInd = new List<uint>{
            0, 1, 2,
            2, 3, 0,

            4, 5, 6,
            6, 7, 4,

            8, 9, 10,
            10, 11, 8,

            12, 13, 14,
            14, 15, 12,

            16, 17, 18,
            18, 19, 16,

            20, 21, 22,
            22, 23, 20
            };
            objectMove = 8;
            objectSize = 0;
        }

        public void BuildObject(String path)
        {
            gameVAO = new VAO();
            gameVAO.Bind();

            gameVertexVBO = new VBO(gameVerts);
            gameVertexVBO.Bind();
            gameVAO.LinkToVAO(0, 3, gameVertexVBO);

            gameGraphicVBO = new VBO(gameGraphic);
            gameGraphicVBO.Bind();
            gameVAO.LinkToVAO(1, 2, gameGraphicVBO);

            gameIBO = new IBO(gameInd);

            texture = new Texture(path);
        }

        public void Render(ShaderProgram program) 
        {
            program.Bind();
            gameVAO.Bind();
            gameIBO.Bind();
            texture.Bind();
            GL.DrawElements(PrimitiveType.Triangles, gameInd.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void Delete()
        {
            gameVAO.Delete();
            gameVertexVBO.Delete();
            gameGraphicVBO.Delete();
            gameIBO.Delete();
            texture.Delete();
        }



        // --- GAME LOGIC ---
        static float BotSpeed = 0.00225f;
        int Player=0;
        int Alive=1;
        public Vector3 position;
        float objectSize = 1f;
        int objectMove;
        List<Vector3> typeOfMove = new List<Vector3>()
        {
            new Vector3(BotSpeed, 0, 0),
            new Vector3(-BotSpeed, 0, 0),
            new Vector3(0, BotSpeed, 0),
            new Vector3(0, -BotSpeed, 0),
            new Vector3(BotSpeed, BotSpeed, 0),
            new Vector3(BotSpeed, -BotSpeed, 0),
            new Vector3(-BotSpeed, BotSpeed, 0),
            new Vector3(-BotSpeed, -BotSpeed, 0),
            new Vector3(0,0,0)
        };
        float coeffabsorb = 1f;

        public void MakePlayer()
        {
            Random rnd = new Random();
            Player = 1;
            objectSize = rnd.Next(3, 5) / 10f + 0.4f;
            position = Vector3.Zero;
        }

        //return 1 - you have been eaten
        public int Intersection(GameObject gameObject)
        {
            if (Square(position.X - gameObject.position.X) + Square(position.Y - gameObject.position.Y) > 0.6f * max(objectSize, gameObject.objectSize))
            {
                return 0;
            }

            if (objectSize > gameObject.objectSize)
            {
                gameObject.Alive = 0;
                objectSize += gameObject.objectSize * coeffabsorb;
                coeffabsorb -= 0.05f;
                coeffabsorb = max(coeffabsorb, 0.05f);
                return 2;
            }
            else
            {
                Alive = 0;
                gameObject.objectSize += objectSize * gameObject.coeffabsorb;
                gameObject.coeffabsorb -= 0.05f;
                gameObject.coeffabsorb = max(gameObject.coeffabsorb, 0.05f);
                return 1;
            }
        }

        public void ChangeTypeOfPosition()
        {
            Random rnd = new Random();
            objectMove = rnd.Next(typeOfMove.Count);
        }
        public bool isAlive()
        {
            return Alive == 1;
        }
        public Vector3 getSize()
        {
            return new Vector3(0, 0, -7 + objectSize);
        }

        public void ChangePosition(Vector3 Pmove)
        {
                Vector3 x = position;
                x += Pmove + typeOfMove[objectMove];
                position = Clamp(x);
        }

        public Vector3 Clamp(Vector3 x)
        {
            Vector3 ans = Vector3.Zero;
            int val = 8;
            if (type == 1)
                val = 18;
            if (x.X > val) ans.X = val;
            else if (x.X < -val) ans.X = -val;
            else
                ans.X = x.X;

            if (x.Y > val) ans.Y = val;
            else if (x.Y < -val) ans.Y = -val;
            else
                ans.Y = x.Y;

            ans.Z = x.Z;

            return ans;
        }

        public float max(float a, float b)
        {
            if (a > b)
                return a;
            return b;
        }

        public float min(float a, float b)
        {
            if (a < b)
                return a;
            return b;
        }

        public float Square(float x)
        { return x * x; }

    }
}
