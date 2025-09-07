export const ReadingStatusEnum = {
  NotStarted: "NotStarted",
  Reading: "Reading",
  Finished: "Finished",
  Abandoned: "Abandoned"
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
