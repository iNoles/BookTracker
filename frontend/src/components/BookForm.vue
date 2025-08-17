<script setup lang="ts">
import { reactive } from 'vue'
import type { Book } from '../types/Book'

const props = defineProps<{
  book?: Book
}>()

const emit = defineEmits<{
  (e: 'submit', book: Book): void
}>()

const form = reactive<Book>({
  id: props.book?.id,
  title: props.book?.title ?? '',
  author: props.book?.author ?? '',
  genre: props.book?.genre ?? '',
  isRead: props.book?.isRead ?? false
})

function handleSubmit() {
  emit('submit', { ...form })
}
</script>

<template>
  <form @submit.prevent="handleSubmit" class="max-w-md mx-auto bg-white shadow p-6 rounded-lg">
    <label class="block mb-2 text-gray-700">Title</label>
    <input v-model="form.title" class="w-full p-2 border rounded mb-4" placeholder="Book Title" />

    <label class="block mb-2 text-gray-700">Author</label>
    <input v-model="form.author" class="w-full p-2 border rounded mb-4" placeholder="Author" />

    <label class="block mb-2 text-gray-700">Genre</label>
    <input v-model="form.genre" class="w-full p-2 border rounded mb-4" placeholder="Genre" />

    <label class="flex items-center mb-4">
      <input type="checkbox" v-model="form.isRead" class="mr-2"/>
      Read
    </label>

    <button type="submit" class="w-full bg-green-500 text-white py-2 rounded hover:bg-green-600">
      Save Book
    </button>
  </form>
</template>
