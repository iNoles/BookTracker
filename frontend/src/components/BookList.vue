<script setup lang="ts">
import type { Book } from '../types/Book'

defineProps<{
  books: Book[]
}>()

const emit = defineEmits<{
  (e: 'edit', book: Book): void
  (e: 'delete', id: number): void
}>()

function addBook() {
  alert('Add Book clicked!')
}
</script>
<template>
<header class="bg-blue-600 text-white shadow-md">
    <div class="max-w-7xl mx-auto px-6 py-4 flex justify-center">
      <h1 class="text-2xl font-bold tracking-wide">Book Tracker</h1>
    </div>
  </header>

  <div class="p-6 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
    <div 
      v-for="book in books" 
      :key="book.id" 
      class="bg-white rounded-2xl shadow-md hover:shadow-xl transition-shadow duration-300 flex flex-col overflow-hidden"
    >
      <!-- Title Bar -->
      <div class="bg-gradient-to-r from-blue-500 to-blue-600 text-white px-4 py-2">
        <h2 class="text-lg font-bold truncate">{{ book.title }}</h2>
      </div>

      <!-- Card Body -->
      <div class="p-4 flex flex-col flex-1">
        <p class="text-gray-600 mb-1"><span class="font-medium">Author:</span> {{ book.author }}</p>
        <p class="text-gray-400 mb-2"><span class="font-medium">Genre:</span> {{ book.genre }}</p>
        <span 
          :class="book.isRead ? 'text-green-600 font-semibold' : 'text-red-600 font-semibold'"
          class="mb-4"
        >
          {{ book.isRead ? 'Read' : 'Unread' }}
        </span>

        <div class="mt-auto flex justify-between gap-2">
          <button 
            @click="emit('edit', book)" 
            class="flex-1 bg-blue-500 text-white py-2 rounded-xl hover:bg-blue-600 transition-colors duration-200"
          >
            Edit
          </button>
          <button 
            @click="emit('delete', book.id!)" 
            class="flex-1 bg-red-500 text-white py-2 rounded-xl hover:bg-red-600 transition-colors duration-200"
          >
            Delete
          </button>
        </div>
      </div>
    </div>
  </div>

  <!-- Floating Action Button -->
  <button
    class="fixed bottom-6 right-6 bg-blue-600 hover:bg-blue-700 text-white rounded-full w-16 h-16 shadow-lg flex items-center justify-center text-3xl transition-colors duration-200"
    @click="addBook"
  >
    +
  </button>
</template>

