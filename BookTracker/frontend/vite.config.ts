import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import tailwindcss from '@tailwindcss/vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue(), tailwindcss()],
  server: {
    proxy: {
      '/api': 'https://localhost:5238' // backend during dev
    }
  },
  build: {
    outDir: '../wwwroot',   // send built files to ASP.NET Core wwwroot
    emptyOutDir: true
  }
})
