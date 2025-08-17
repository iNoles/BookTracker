<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { Book } from './Book'
import { getBooks, addBook, updateBook, deleteBook } from './bookService'
import BookList from './components/BookList.vue'
import BookForm from './components/BookForm.vue'

const books = ref<Book[]>([])
const editingBook = ref<Book | null>(null)

async function fetchBooks() {
  books.value = await getBooks()
}

function editBook(book: Book) {
  editingBook.value = { ...book }
}

async function saveBook(book: Book) {
  if (book.id) {
    await updateBook(book)
  } else {
    await addBook(book)
  }
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
    <BookForm v-if="editingBook" :book="editingBook" @submit="saveBook" />
    <BookList :books="books" @edit="editBook" @delete="removeBook"/>
  </div>
</template>
