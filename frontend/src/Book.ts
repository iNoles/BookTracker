export const ReadingStatusEnum = {
  NotStarted: 0,
  Reading: 1,
  Finished: 2,
  Abandoned: 3
} as const;

export type ReadingStatus = typeof ReadingStatusEnum[keyof typeof ReadingStatusEnum];

export interface Book {
  id?: number
  title: string
  author: string
  genre: string
  notes?: string
  rating?: number
  status: ReadingStatus
}
