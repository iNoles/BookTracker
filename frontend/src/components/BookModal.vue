<script setup lang="ts">
import { ref, watch } from 'vue'
import type { Book } from '../types/Book'

// Props
const props = defineProps<{
  show: boolean
  book: Book | null
}>()

// Emits
const emit = defineEmits<{
  (e: 'save', book: Book): void
  (e: 'close'): void
}>()

// Local copy of the book to edit/add
const localBook = ref<Book>({
  title: '',
  author: '',
  genre: '',
  isRead: false,
})

// Sync localBook whenever prop changes
watch(
  () => props.book,
  (newBook) => {
    if (newBook) {
      localBook.value = { ...newBook }
    } else {
      localBook.value = { title: '', author: '', genre: '', isRead: false }
    }
  },
  { immediate: true }
)

// Save handler
function save() {
  emit('save', { ...localBook.value })
}

// Cancel handler
function cancel() {
  emit('close')
}
</script>

<template>
  <div v-if="props.show" class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
    <div class="bg-white rounded-2xl shadow-lg w-full max-w-md p-6">
      <h2 class="text-2xl font-bold text-blue-600 mb-4 text-center">
        {{ props.book ? 'Edit Book' : 'Add New Book' }}
      </h2>

      <form @submit.prevent="save" class="space-y-4">
        <div>
          <label class="block text-gray-700 font-medium mb-1">Title</label>
          <input v-model="localBook.title" type="text" class="w-full px-4 py-2 border rounded-lg" />
        </div>
        <div>
          <label class="block text-gray-700 font-medium mb-1">Author</label>
          <input v-model="localBook.author" type="text" class="w-full px-4 py-2 border rounded-lg" />
        </div>
        <div>
          <label class="block text-gray-700 font-medium mb-1">Genre</label>
          <input v-model="localBook.genre" type="text" class="w-full px-4 py-2 border rounded-lg" />
        </div>
        <div class="flex items-center">
          <input v-model="localBook.isRead" type="checkbox" id="isRead" class="mr-2" />
          <label for="isRead">Mark as Read</label>
        </div>

        <div class="flex justify-end gap-3">
          <button type="button" @click="cancel" class="px-4 py-2 bg-gray-300 rounded-lg">Cancel</button>
          <button type="submit" class="px-4 py-2 bg-blue-600 text-white rounded-lg">Save</button>
        </div>
      </form>
    </div>
  </div>
</template>
