import axios from 'axios'
import type { Book } from './Book'

const API_URL = 'http://localhost:5238/api/books'

export async function getBooks(): Promise<Book[]> {
  const res = await axios.get<Book[]>(API_URL)
  return res.data
}

export async function addBook(book: Book): Promise<void> {
  await axios.post(API_URL, book)
}

export async function updateBook(book: Book): Promise<void> {
  await axios.put(`${API_URL}/${book.id}`, book)
}

export async function deleteBook(id: number): Promise<void> {
  await axios.delete(`${API_URL}/${id}`)
}
