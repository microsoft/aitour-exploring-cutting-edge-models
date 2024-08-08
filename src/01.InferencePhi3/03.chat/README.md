## Demo for showcasing WebGPU 

WebGPU is a modern web graphics API designed to provide efficient access to a device's graphics processing unit (GPU) directly from web browsers. It is intended to be the successor to WebGL, offering several key improvements:

1. **Compatibility with Modern GPUs**: WebGPU is built to work seamlessly with contemporary GPU architectures, leveraging system APIs like Vulkan, Metal, and Direct3D 12.
2. **Enhanced Performance**: It supports general-purpose GPU computations and faster operations, making it suitable for both graphics rendering and machine learning tasks.
3. **Advanced Features**: WebGPU provides access to more advanced GPU capabilities, enabling more complex and dynamic graphics and computational workloads.
4. **Reduced JavaScript Workload**: By offloading more tasks to the GPU, WebGPU significantly reduces the workload on JavaScript, leading to better performance and smoother experiences.

WebGPU is currently supported in browsers like Google Chrome, with ongoing work to expand support to other platforms.

### 03.WebGPU
Required Environment:

**Supported browsers:** 
- Google Chrome 113+
- Microsoft Edge 113+
- Safari 18 (macOS 15)
- Firefox Nightly.

### Enable WebGPU:
- In Chrome/Microsoft Edge, enable the `chrome://flags/#enable-unsafe-webgpu` flag.
- For Linux, launch the browser with `--enable-features=Vulkan`.
- Safari 18 (macOS 15) has WebGPU enabled by default.
- In Firefox Nightly, enter about:config in the address bar and `set dom.webgpu.enabled to true`.

Run the following command to get strated 
```
npm run build
```
```
npm run dev
```

### WebGPU Demo

**Note:** The model needs to be cached in the browser, so it may take some time to load. Upload the markdown file `intro_rag.md` to complete the RAG solution.