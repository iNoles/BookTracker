<script setup lang="ts">
import type { Book } from '../types/Book'

defineProps<{
  books: Book[]
}>()

const emit = defineEmits<{
  (e: 'edit', book: Book): void
  (e: 'delete', id: number): void
}>()

// Map numeric status to display string
function statusText(status: ReadingStatus) {
  switch (status) {
    case 0: return 'Not Started'
    case 1: return 'Reading'
    case 2: return 'Finished'
    case 3: return 'Abandoned'
    default: return 'Not Started'
  }
}

// Map numeric status to Tailwind badge colors
function statusColor(status: ReadingStatus) {
  switch (status) {
    case 2: return 'bg-green-100 text-green-700 border-green-300'
    case 1: return 'bg-yellow-100 text-yellow-700 border-yellow-300'
    case 3: return 'bg-red-100 text-red-700 border-red-300'
    case 0:
    default: return 'bg-gray-100 text-gray-700 border-gray-300'
  }
}
</script>

<template>
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
        
        <p v-if="book.notes" class="text-sm italic text-gray-600">Notes: {{ book.notes }}</p>
        <p v-if="book.rating" class="text-sm">Rating: 
          <span v-for="n in book.rating" :key="n" class="text-yellow-500">⭐</span>
        </p>

        <!-- Status Badge -->
        <span 
          class="inline-block mt-2 px-3 py-1 text-xs font-medium rounded-full border w-fit"
          :class="statusColor(book.status)"
        >
           {{ statusText(book.status) }}
        </span>

        <!-- Actions -->
        <div class="mt-auto flex justify-between gap-2 pt-4">
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
</template>
