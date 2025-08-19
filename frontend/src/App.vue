<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { Book } from './types/Book'
import BookList from './components/BookList.vue'
import BookModal from './components/BookModal.vue'
import { getBooks, addBook, updateBook, deleteBook } from './bookService'

const books = ref<Book[]>([])
const showModal = ref(false)
const editingBook = ref<Book | null>(null)

async function fetchBooks() {
  books.value = await getBooks()
}

function addNewBook() {
  editingBook.value = null
  showModal.value = true
}

function editBook(book: Book) {
  editingBook.value = { ...book }
  showModal.value = true
}

async function saveBook(book: Book) {
  if (editingBook.value) {
    await updateBook(book)
  } else {
    await addBook(book)
  }
  showModal.value = false
  editingBook.value = null
  await fetchBooks()
}

async function removeBook(id: number) {
  await deleteBook(id)
  await fetchBooks()
}

onMounted(fetchBooks)
</script>

<template>
  <div class="p-6">
    <!-- Header -->
    <header class="bg-blue-600 text-white shadow-md mb-6">
      <div class="max-w-7xl mx-auto px-6 py-4 flex justify-center">
        <h1 class="text-2xl font-bold tracking-wide">Book Tracker</h1>
      </div>
    </header>

    <!-- Book Cards -->
    <BookList 
      :books="books" 
      @edit="editBook" 
      @delete="removeBook"
    />

    <!-- Floating Add Button -->
    <button
      @click="addNewBook"
      class="fixed bottom-6 right-6 bg-blue-600 text-white w-14 h-14 rounded-full shadow-lg 
             flex items-center justify-center text-3xl hover:bg-blue-700 transition"
    >
      +
    </button>

    <!-- Add/Edit Modal -->
    <BookModal 
      :show="showModal"
      :book="editingBook"
      @save="saveBook"
      @close="() => { showModal = false; editingBook = null }"
    />
  </div>
</template>
