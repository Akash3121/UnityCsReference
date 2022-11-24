// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Bindings;

namespace UnityEditor.LightBaking
{
    [NativeHeader("Editor/Src/GI/LightBaker/LightBaker.Bindings.h")]
    [StaticAccessor("LightBakerBindings", StaticAccessorType.DoubleColon)]
    internal static class LightBaker
    {
        public enum ResultType : UInt32
        {
            Success = 0,
            Cancelled,
            JobFailed,
            OutOfMemory,
            InvalidInput,
            LowLevelAPIFailure,
            IOFailed,
            Undefined
        }

        public struct Result
        {
            public ResultType type;
            public String message;
            public override string ToString()
            {
                if (message.Length == 0)
                    return $"Result type: '{type}'";
                else
                    return $"Result type: '{type}', message: '{message}'";

            }
        }


        public enum Backend
        {
            CPU = 0,
            GPU = 1
        }
        public enum TransmissionChannels
        {
            Red = 0,
            Alpha = 1,
            AlphaCutout = 2,
            RGB = 3,
            None = 4
        }
        public enum TransmissionType
        {
            Opacity = 0,
            Transparency = 1,
            None = 2
        }
        public enum MeshType
        {
            Terrain = 0,
            MeshRenderer = 1
        }
        public enum MixedLightingMode
        {
            IndirectOnly = 0,
            Subtractive = 1,
            Shadowmask = 2,
        };
        public enum LightmapBakeMode
        {
            NonDirectional = 0,
            CombinedDirectional = 1
        };
        [Flags]
        public enum ProbeRequestOutputType : UInt32
        {
            RadianceDirect = 1 << 0,
            RadianceIndirect = 1 << 1,
            Validity = 1 << 2,
            MixedLightOcclusion = 1 << 3,
            LightProbeOcclusion = 1 << 4,
            EnvironmentOcclusion = 1 << 5,
            Depth = 1 << 6,
            All = 0xFFFFFFFF
        };
        public struct ProbeRequest
        {
            public ProbeRequestOutputType outputTypeMask;
            public UInt64 positionOffset;
            public UInt64 positionLength;
            public float pushoff;
            public string outputFolderPath;
        };
        [Flags]
        public enum LightmapRequestOutputType : UInt32
        {
            IrradianceIndirect = 1 << 0,
            IrradianceDirect = 1 << 1,
            IrradianceEnvironment = 1 << 2,
            Occupancy = 1 << 3,
            Validity = 1 << 4,
            DirectionalityIndirect = 1 << 5,
            DirectionalityDirect = 1 << 6,
            AmbientOcclusion = 1 << 7,
            Shadowmask = 1 << 8,
            Normal = 1 << 9,
            ChartIndex = 1 << 10,
            OverlapPixelIndex = 1 << 11,
            All = 0xFFFFFFFF
        };
        public enum TilingMode
        {   // Assuming a 4k lightmap (16M texels), the tiling will yield the following chunk sizes:
            None = 0,                 // 4k * 4k =    16M texels
            Quarter = 1,              // 2k * 2k =     4M texels
            Sixteenth = 2,            // 1k * 1k =     1M texels
            Sixtyfourth = 3,          // 512 * 512 = 262k texels
            TwoHundredFiftySixth = 4, // 256 * 256 =  65k texels
            Max = TwoHundredFiftySixth,
            Error = 5                 // Error. We don't want to go lower (GPU occupancy will start to be a problem for smaller atlas sizes).
        };
        public struct LightmapRequest
        {
            public LightmapRequestOutputType outputTypeMask;
            public UInt32 lightmapOffset;
            public UInt32 lightmapCount;
            public TilingMode tilingMode;
            public string outputFolderPath;
        };
        public struct Resolution
        {
            public Resolution(UInt32 widthIn, UInt32 heightIn)
            {
                width = widthIn;
                height = heightIn;
            }
            public UInt32 width;
            public UInt32 height;
        }

        public struct TextureData
        {
            public TextureData(Resolution resolutionIn)
            {
                resolution = resolutionIn;
                data = new Vector4[resolution.width * resolution.height];
            }
            public Resolution resolution;
            public Vector4[] data;
        }

        public struct CookieData
        {
            public CookieData(Resolution resolutionIn, UInt32 pixelStrideIn, UInt32 slicesIn, bool repeatIn)
            {
                resolution = resolutionIn;
                pixelStride = pixelStrideIn;
                slices = slicesIn;
                repeat = repeatIn;
                data = new byte[resolution.width * resolution.height * slices* pixelStride];
            }
            public Resolution resolution;
            public UInt32 pixelStride;
            public UInt32 slices;
            public bool repeat;
            public byte[] data;
        }

        public struct Instance
        {
            public MeshType meshType;
            public int meshIndex; // index into BakeInput::m_MeshData, -1 for Terrain
            public int terrainIndex; // index into BakeInput::m_TerrainData, -1 for MeshRenderer
            public Matrix4x4 transform;
            public bool castShadows;
            public bool receiveShadows;
            public bool oddNegativeScale;
            public int lodGroup;
            public byte lodMask;
            public int[] submeshMaterialIndices;
        }

        public struct Terrain
        {
            public UInt32 heightMapIndex; // index into BakeInput::m_HeightmapData
            public int terrainHoleIndex; // index into BakeInput::m_TerrainHoleData -1 means no hole data
            public float outputResolution;
            public Vector3 heightmapScale;
            public Vector4 uvBounds;
        }

        public struct Material
        {
            public bool doubleSidedGI;
            public TransmissionChannels transmissionChannels;
            public TransmissionType transmissionType;
        }

        public enum LightType : byte
        {
            Directional = 0,
            Point = 1,
            Spot = 2,
            Rectangle = 3,
            Disc = 4,
            SpotPyramidShape = 5,
            SpotBoxShape = 6
        };

        public enum FalloffType : byte
        {
            InverseSquared = 0,
            InverseSquaredNoRangeAttenuation = 1,
            Linear = 2,
            Legacy = 3
        };

        public enum AngularFalloffType : byte
        {
            LUT = 0,
            AnalyticAndInnerAngle = 1
        };

        public enum LightMode : byte
        {
            Realtime = 0,
            Mixed = 1,
            Baked = 2
        };

        public struct Light
        {
            public Vector3 color;
            public Vector3 indirectColor;
            public Quaternion orientation;
            public Vector3 position;
            public float range;
            public Int32 cookieTextureIndex;
            public float cookieScale;
            public float coneAngle;
            public float innerConeAngle;
            public float shape0;
            public float shape1;
            public LightType type;
            public LightMode mode;
            public FalloffType falloff;
            public AngularFalloffType angularFalloff;
            public bool castsShadows;
            public Int32 shadowMaskChannel;
        }

        public struct SampleCount
        {
            public UInt32 directSampleCount;
            public UInt32 indirectSampleCount;
            public UInt32 environmentSampleCount;
        };

        public struct LightingSettings
        {
            public SampleCount lightmapSampleCounts;
            public SampleCount probeSampleCounts;
            public UInt32 minBounces;
            public UInt32 maxBounces;
            public LightmapBakeMode lightmapBakeMode;
            public MixedLightingMode mixedLightingMode;
            public bool aoEnabled;
            public float aoDistance;
        };

        [StructLayout(LayoutKind.Sequential)]
        public class BakeInput : IDisposable
        {
            internal IntPtr m_Ptr;
            internal bool m_OwnsPtr;

            public BakeInput()
            {
                m_Ptr = Internal_Create();
                m_OwnsPtr = true;
            }
            public BakeInput(IntPtr ptr)
            {
                m_Ptr = ptr;
                m_OwnsPtr = false;
            }
            ~BakeInput()
            {
                Destroy();
            }

            public void Dispose()
            {
                Destroy();
                GC.SuppressFinalize(this);
            }

            void Destroy()
            {
                if (m_OwnsPtr && m_Ptr != IntPtr.Zero)
                {
                    Internal_Destroy(m_Ptr);
                    m_Ptr = IntPtr.Zero;
                }
            }

            extern public UInt64 GetByteSize();

            public Texture2D GetAlbedoTexture(UInt32 index)
            {
                if (index >= albedoTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (albedoTextureCount - 1) + ", but was {0}", index));
                TextureData textureData = GetAlbedoTextureData(index);
                var tex = new Texture2D((int)textureData.resolution.width, (int)textureData.resolution.height, TextureFormat.RGBAFloat, false);
                tex.SetPixelData(textureData.data, 0);
                tex.filterMode = FilterMode.Point;
                tex.Apply();
                return tex;
            }

            public Texture2D GetEmissiveTexture(UInt32 index)
            {
                if (index >= emissiveTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (emissiveTextureCount - 1) + ", but was {0}", index));
                TextureData textureData = GetEmissiveTextureData(index);
                var tex = new Texture2D((int)textureData.resolution.width, (int)textureData.resolution.height, TextureFormat.RGBAFloat, false);
                tex.SetPixelData(textureData.data, 0);
                tex.filterMode = FilterMode.Point;
                tex.Apply();
                return tex;
            }

            static extern IntPtr Internal_Create();
            [NativeMethod(IsThreadSafe = true)]
            static extern void Internal_Destroy(IntPtr ptr);

            extern LightingSettings Internal_GetLightingSettings();
            public LightingSettings GetLightingSettings()
            {
                return Internal_GetLightingSettings();
            }
            extern void Internal_SetLightingSettings(LightingSettings lightingSettings);
            public void SetLightingSettings(LightingSettings lightingSettings)
            {
                Internal_SetLightingSettings(lightingSettings);
            }

            extern UInt32 Internal_LightmapWidth(UInt32 index);
            extern UInt32 Internal_LightmapHeight(UInt32 index);
            extern UInt32 Internal_InstanceCount(UInt32 lightmapIndex);

            extern public UInt32 instanceCount { get; }
            extern Instance Internal_Instance(UInt32 index);
            public Instance instance(UInt32 index)
            {
                if (index >= instanceCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (instanceCount - 1) + ", but was {0}", index));
                Instance instance = Internal_Instance(index);
                return instance;
            }

            extern public UInt32 terrainCount { get; }
            extern Terrain Internal_GetTerrain(UInt32 index);
            public Terrain GetTerrain(UInt32 index)
            {
                if (index >= terrainCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (terrainCount - 1) + ", but was {0}", index));
                Terrain terrain = Internal_GetTerrain(index);
                return terrain;
            }

            public UInt32 lightmapInstanceCount(UInt32 index)
            {
                if (index >= lightmapCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (lightmapCount - 1) + ", but was {0}", index));
                return Internal_InstanceCount(index);
            }

            extern public UInt32 meshCount { get; }
            extern public UInt32 heightmapCount { get; }
            extern public UInt32 holemapCount { get; }
            extern public UInt32 materialCount { get; }
            extern Material Internal_GetMaterial(UInt32 index);
            extern void Internal_SetMaterial(UInt32 index, Material material);
            public Material GetMaterial(UInt32 index)
            {
                if (index >= materialCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (materialCount - 1) + ", but was {0}", index));
                Material material = Internal_GetMaterial(index);
                return material;
            }
            public void SetMaterial(UInt32 index, Material material)
            {
                if (index >= materialCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (materialCount - 1) + ", but was {0}", index));
                Internal_SetMaterial(index, material);
            }
            public int GetMaterialIndex(UInt32 instanceIndex, UInt32 submeshIndex)
            {
                if (instanceIndex >= instanceCount)
                    throw new ArgumentException(string.Format("instanceIndex must be between 0 and " + (instanceCount - 1) + ", but was {0}", instanceIndex));
                Instance theInstance = instance(instanceIndex);
                if (theInstance.submeshMaterialIndices.Length == 0)
                    throw new ArgumentException(string.Format("instance {0} has not materials", instanceIndex));
                if (submeshIndex >= theInstance.submeshMaterialIndices.Length)
                    throw new ArgumentException(string.Format("submeshIndex must be between 0 and " + (theInstance.submeshMaterialIndices.Length - 1) + ", but was {0}", submeshIndex));
                return theInstance.submeshMaterialIndices[submeshIndex];
            }
            extern UInt32 Internal_GetLightCount();
            public UInt32 GetLightCount()
            {
                return Internal_GetLightCount();
            }
            extern Light Internal_GetLight(UInt32 index);
            extern void Internal_SetLight(UInt32 index, Light light);
            public Light GetLight(UInt32 index)
            {
                if (index >= GetLightCount())
                    throw new ArgumentException(string.Format("index must be between 0 and " + (GetLightCount() - 1) + ", but was {0}", index));
                return Internal_GetLight(index);
            }
            public void SetLight(UInt32 index, Light light)
            {
                if (index >= GetLightCount())
                    throw new ArgumentException(string.Format("index must be between 0 and " + (GetLightCount() - 1) + ", but was {0}", index));
                Internal_SetLight(index, light);
            }

            extern Int32 Internal_instanceAlbedoEmissiveIndex(UInt32 instanceIndex);
            extern Int32 Internal_instanceTransmissiveIndex(UInt32 instanceIndex, UInt32 submeshIndex);
            public Int32 instanceToAlbedoIndex(UInt32 instanceIndex)
            {
                if (instanceIndex >= instanceCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (instanceCount - 1) + ", but was {0}", instanceIndex));
                return Internal_instanceAlbedoEmissiveIndex(instanceIndex);
            }
            public Int32 instanceToEmissiveIndex(UInt32 instanceIndex)
            {
                if (instanceIndex >= instanceCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (instanceCount - 1) + ", but was {0}", instanceIndex));
                return Internal_instanceAlbedoEmissiveIndex(instanceIndex);
            }
            public Int32 instanceToTransmissiveIndex(UInt32 instanceIndex, UInt32 submeshIndex)
            {
                if (instanceIndex >= instanceCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (instanceCount - 1) + ", but was {0}", instanceIndex));
                Instance inst = instance(instanceIndex);
                int submeshCount = inst.submeshMaterialIndices.Length;
                if (submeshIndex >= submeshCount)
                    throw new ArgumentException(string.Format("submeshIndex must be between 0 and " + (submeshCount - 1) + ", but was {0}", submeshIndex));
                int materialIndex = inst.submeshMaterialIndices[submeshIndex];
                if (materialIndex == -1)
                    throw new ArgumentException(string.Format("material for submesh {0} did not exist.", submeshIndex));

                return Internal_instanceTransmissiveIndex(instanceIndex, submeshIndex);
            }

            extern public UInt32 albedoTextureCount { get; }
            extern TextureData Internal_GetAlbedoTextureData(UInt32 index);
            extern void Internal_SetAlbedoTextureData(UInt32 index, TextureData textureData);

            public TextureData GetAlbedoTextureData(UInt32 index)
            {
                if (index >= albedoTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (albedoTextureCount - 1) + ", but was {0}", index));
                return Internal_GetAlbedoTextureData(index);
            }
            public void SetAlbedoTextureData(UInt32 index, TextureData textureData)
            {
                if (index >= albedoTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (albedoTextureCount - 1) + ", but was {0}", index));
                Internal_SetAlbedoTextureData(index, textureData);
            }

            extern public UInt32 emissiveTextureCount { get; }
            extern public UInt32 transmissiveTextureCount { get; }
            extern TextureData Internal_GetEmissiveTextureData(UInt32 index);
            extern void Internal_SetEmissiveTextureData(UInt32 index, TextureData textureData);
            public TextureData GetEmissiveTextureData(UInt32 index)
            {
                if (index >= emissiveTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (emissiveTextureCount - 1) + ", but was {0}", index));
                return Internal_GetEmissiveTextureData(index);
            }
            public void SetEmissiveTextureData(UInt32 index, TextureData textureData)
            {
                if (index >= emissiveTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (emissiveTextureCount - 1) + ", but was {0}", index));
                Internal_SetEmissiveTextureData(index, textureData);
            }

            extern TextureData Internal_GetTransmissiveTextureData(UInt32 index);
            extern void Internal_SetTransmissiveTextureData(UInt32 index, TextureData textureData);
            public TextureData GetTransmissiveTextureData(UInt32 index)
            {
                if (index >= transmissiveTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (transmissiveTextureCount - 1) + ", but was {0}", index));
                return Internal_GetTransmissiveTextureData(index);
            }
            public void SetTransmissiveTextureData(UInt32 index, TextureData textureData)
            {
                if (index >= emissiveTextureCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (transmissiveTextureCount - 1) + ", but was {0}", index));
                Internal_SetTransmissiveTextureData(index, textureData);
            }

            extern public UInt32 GetCookieCount();
            extern CookieData Internal_GetCookieData(UInt32 index);
            extern void Internal_SetCookieData(UInt32 index, CookieData cookieData);
            public CookieData GetCookieData(UInt32 index)
            {
                if (index >= GetCookieCount())
                    throw new ArgumentException(string.Format("index must be between 0 and " + (GetCookieCount() - 1) + ", but was {0}", index));
                return Internal_GetCookieData(index);
            }
            public void SetCookieData(UInt32 index, CookieData cookieData)
            {
                if (index >= GetCookieCount())
                    throw new ArgumentException(string.Format("index must be between 0 and " + (GetCookieCount() - 1) + ", but was {0}", index));
                Internal_SetCookieData(index, cookieData);
            }

            extern public UInt32 lightmapCount { get; }
            public Resolution lightmapResolution(UInt32 index)
            {
                if (index >= lightmapCount)
                    throw new ArgumentException(string.Format("index must be between 0 and " + (lightmapCount - 1) + ", but was {0}", index));
                Resolution resolution;
                resolution.width = Internal_LightmapWidth(index);
                resolution.height = Internal_LightmapHeight(index);
                return resolution;
            }
            extern public UInt32 lightProbeCount { get; }

            extern public void SetLightmapResolution(Resolution resolution);
            extern public void SetEnvironment(Vector4 color);

            extern public void SetBackend(Backend backend);
            public extern ProbeRequest[] GetProbeRequests();
            public extern void SetLightProbeRequests(ProbeRequest[] requests);
            public extern LightmapRequest[] GetLightmapRequests();
            public extern void SetLightmapRequests(LightmapRequest[] requests);

            private extern unsafe void SetProbePositions([Span("positionsLength", isReadOnly: true)] Vector3* positions, int positionsLength);

            public void SetProbePositions(Vector3[] positions)
            {
                SetProbePositions(positions.AsSpan());
            }
            public unsafe void SetProbePositions(ReadOnlySpan<Vector3> positions)
            {
                fixed (Vector3* positionsPtr = positions)
                {
                    SetProbePositions(positionsPtr, positions.Length);
                }
            }
            public extern Vector3[] GetProbePositions();
        }
        extern static public Result Bake(BakeInput input);
    }
}
