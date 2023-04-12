export class VijestiVM
{
  id:number;
  naslov:string;
  tekst:string;
  datum:string;
  autor:string;
  ImamId:number;
  image_nova_base64:string;
  opis:string;
}
export interface VijestiVMPagedList {
  dataItems: VijestiVM[]
  currentPage: number
  totalPages: number
  pageSize: number
  totalCount: number
  hasPrevios: boolean
  hasNext: boolean
}

