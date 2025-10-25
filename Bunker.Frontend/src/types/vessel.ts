export interface Vessel {
  id: number
  imo: string
  name: string
  vesselType: string
  flag: string
  grossTonnage?: number
  deadweightTonnage?: number
  lengthOverall?: number
  beam?: number
  draft?: number
  yearBuilt?: number
  owner?: string
  status: string
  maxCrew?: number
  enginePowerKW?: number
  maxSpeedKnots?: number
  callSign?: string
  mmsi?: string
  createdAt: string
  updatedAt?: string
  createdBy?: string
  updatedBy?: string
  notes?: string
}

export interface CreateVesselRequest {
  imo: string
  name: string
  vesselType: string
  flag: string
  grossTonnage?: number
  deadweightTonnage?: number
  lengthOverall?: number
  beam?: number
  draft?: number
  yearBuilt?: number
  owner?: string
  status: string
  maxCrew?: number
  enginePowerKW?: number
  maxSpeedKnots?: number
  callSign?: string
  mmsi?: string
  createdBy?: string
  notes?: string
}

export interface UpdateVesselRequest extends CreateVesselRequest {
  id: number
}

export interface VesselListResponse {
  vessels: Vessel[]
  totalCount: number
  pageNumber: number
  pageSize: number
  totalPages: number
}

export interface VesselListQuery {
  name?: string
  imo?: string
  mmsi?: string
  callSign?: string
  vesselType?: string
  flag?: string
  status?: string
  yearBuilt?: number
  yearBuiltFrom?: number
  yearBuiltTo?: number
  pageNumber?: number
  pageSize?: number
}

export interface ApiResponse<T> {
  success: boolean
  data?: T
  message?: string
  errors?: string[]
}

export interface PaginationInfo {
  pageNumber: number
  pageSize: number
  totalCount: number
  totalPages: number
}
