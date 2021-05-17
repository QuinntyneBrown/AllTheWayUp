import { Track } from "../tracks/track";

export type Artist = {
    artistId: string;
    name:string;
    tracks: Track[];
};
