export class CommentModel{
  id!: string;
  userName!: string;
  userId!: string;
  text!: string;
  hasAttachment!: boolean;
  createdAt!: Date;
  parentCommentId!: string;
  replies!: CommentModel[];
}

export class CreateCommentModel{
  text!: string;
  parentCommentId: string | undefined;
  formData!: FormData | null;
}

export class UpdateCommentModel{
  id!: string;
  text!: string;
  formData!: FormData | null;
}

export class CommentSubmitModel{
  text!: string;
  formData!: FormData | null;
}

export class CurrentComment{
  id!: string;
  type!: CurrentCommentType;
}

export enum CurrentCommentType{
  reply,
  edit
}

export class PagedCommentList{
  data!: CommentModel[];
  currentPage!: number;
  pageSize!: number;
  totalPages!: number;
}

export class GetCommentsModel{
  sort!: string;
  sortOrder!: string;
  page!: number;
  pageCount!: number;
}
