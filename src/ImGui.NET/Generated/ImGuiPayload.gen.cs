using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe struct ImGuiPayload
    {
        public void* Data;
        public int DataSize;
        public uint SourceId;
        public uint SourceParentId;
        public int DataFrameCount;
        public fixed byte DataType[33];
        public byte Preview;
        public byte Delivery;
    }
    public unsafe struct ImGuiPayloadPtr
    {
        public ImGuiPayload* NativePtr { get; }
        public ImGuiPayloadPtr(ImGuiPayload* nativePtr) => NativePtr = nativePtr;
        public void* Data { get => NativePtr->Data; set => NativePtr->Data = value; }
        public ref int DataSize => ref Unsafe.AsRef<int>(&NativePtr->DataSize);
        public ref uint SourceId => ref Unsafe.AsRef<uint>(&NativePtr->SourceId);
        public ref uint SourceParentId => ref Unsafe.AsRef<uint>(&NativePtr->SourceParentId);
        public ref int DataFrameCount => ref Unsafe.AsRef<int>(&NativePtr->DataFrameCount);
        public ref byte Preview => ref Unsafe.AsRef<byte>(&NativePtr->Preview);
        public ref byte Delivery => ref Unsafe.AsRef<byte>(&NativePtr->Delivery);
        public void Clear()
        {
            ImGuiNative.ImGuiPayload_Clear(NativePtr);
        }
        public void ImGuiPayload()
        {
            ImGuiNative.ImGuiPayload_ImGuiPayload(NativePtr);
        }
        public bool IsPreview()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsPreview(NativePtr);
            return ret != 0;
        }
        public bool IsDataType(string type)
        {
            int type_byteCount = Encoding.UTF8.GetByteCount(type);
            byte* native_type = stackalloc byte[type_byteCount + 1];
            fixed (char* type_ptr = type)
            {
                int native_type_offset = Encoding.UTF8.GetBytes(type_ptr, type.Length, native_type, type_byteCount);
                native_type[native_type_offset] = 0;
            }
            byte ret = ImGuiNative.ImGuiPayload_IsDataType(NativePtr, native_type);
            return ret != 0;
        }
        public bool IsDelivery()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsDelivery(NativePtr);
            return ret != 0;
        }
    }
}
