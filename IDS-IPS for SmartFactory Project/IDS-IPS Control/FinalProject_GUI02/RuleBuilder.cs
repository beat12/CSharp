using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject_GUI02
{
    internal class RuleBuilder
    {
        //Header
        public string mkHeader(rHeader rh)
        {
            string header;
            string SEP = " ";
            header = rh.Action + SEP + rh.Protocol + SEP + rh.SourceIP + SEP + rh.SourcePort + SEP + rh.Direction + SEP + rh.DestIP + SEP + rh.DestPort;

            return header;
        }
        //Option
        public string mkOption(rOption rOpt)
        {
            string option;
            string SEP = " ";
            string END = ";";
            //string QT = "\"";
            //string contents = "";
            
            //foreach (rPayload rp in rOpt.Payload)
            //{
            //    if (string.IsNullOrEmpty(rp.Contents))
            //        continue;
            //    //rp.Contents = rp.Contents.Replace("\\", "\\\\\\\\");    // \ -> \\ 
            //    rp.Contents = rp.Contents.Replace("\\", "\\\\");    // \ -> \\ 
            //    //rp.Contents = rp.Contents.Replace("|", "\\|");      // | -> \|
            //    rp.Contents = rp.Contents.Replace("\"", "\\\"");    // " -> \"
            //    rp.Contents = rp.Contents.Replace(";", "\\;");      // ; -> \;"
            //    rp.Contents = rp.Contents.Replace("|", "|7C|");

            //    contents += "content:\"" + rp.Contents + "\"" + END;
               
            //    contents += SEP;
            //}

            option = "(";
            if (!string.IsNullOrEmpty(rOpt.Content))
                option += " content: " + $"\\\"{rOpt.Content}\\\"" + END + SEP;

            if (!string.IsNullOrEmpty(rOpt.Nocase) && rOpt.Nocase.Equals("Checked"))
                option += SEP + "nocase" + END;
            if (!string.IsNullOrEmpty(rOpt.Rawbytes) && rOpt.Rawbytes.Equals("Checked"))
                option += SEP + "rawbytes" + END;
            if (!string.IsNullOrEmpty(rOpt.Depth))
                option += SEP + "depth: " + rOpt.Depth + END;
            if (!string.IsNullOrEmpty(rOpt.Offset))
                option += SEP + "offset: " + rOpt.Offset + END;
            if (!string.IsNullOrEmpty(rOpt.Distance))
                option += SEP + "distance: " + rOpt.Distance + END;
            if (!string.IsNullOrEmpty(rOpt.Within))
                option += SEP + "within: " + rOpt.Within + END;

            if (!string.IsNullOrEmpty(rOpt.Msg))            
                option += "msg:" + $"\\\"{rOpt.Msg}\\\"" + END + SEP;                       
                

            if (!string.IsNullOrEmpty(rOpt.Pcre))
                option += "pcre: " + $"\\\"{rOpt.Pcre}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Byte_test))
                option += "byte_test: " + $"\\\"{rOpt.Byte_test}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Byte_jump))
                option += "byte_jump: " + $"\\\"{rOpt.Byte_jump}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Ttl))
                option += "ttl: " + $"\\\"{rOpt.Ttl}\\\""  + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Dsize))
                option += "dsize: " + $"\\\"{rOpt.Dsize}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Flags))
                option += "flags: " + $"\\\"{rOpt.Flags}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Flow))
                option += "flow: " + $"\\\"{rOpt.Flow}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Flowbits))
                option += "flowbits: " + rOpt.Flowbits + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Itype))
                option += "itype: "+ $"\\\"{rOpt.Itype}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Icode))
                option += "icode: "+ $"\\\"{rOpt.Icode}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Icmp_id))
                option += "icmp_id: " + $"\\\"{rOpt.Icmp_id}\\\"" + END + SEP;
            if (!string.IsNullOrEmpty(rOpt.Icmp_seq))
                option += "icmp_seq: "+ $"\\\"{rOpt.Icmp_seq}\\\"" + END + SEP;
            
            //if (!string.IsNullOrEmpty(contents))
            //    option += contents + SEP;

            if (!string.IsNullOrEmpty(rOpt.Isdataat))
                option += "isdataat:"+ $"\\\"{rOpt.Isdataat}\\\"" + END + SEP;

            if (!string.IsNullOrEmpty(rOpt.Type))
                option += "trashold:type " + rOpt.Type;
            if (!string.IsNullOrEmpty(rOpt.Track))
                option += ", track " + rOpt.Track;
            if (!string.IsNullOrEmpty(rOpt.Count))
                option += ", count:" + rOpt.Count;
            if (!string.IsNullOrEmpty(rOpt.Second))
                option += ", seconds:" + rOpt.Second;

            if (!string.IsNullOrEmpty(rOpt.Priority))
                option += SEP + "priority: " + rOpt.Priority + END;
            if (!string.IsNullOrEmpty(rOpt.Rev))
                option += SEP + "rev: " + rOpt.Rev + END;

            if (!string.IsNullOrEmpty(rOpt.Sid))
                option += " sid: " + rOpt.Sid+ END + SEP;
            option += ")";

            option = option.Replace("; ;", ";");
            option = option.Replace(";  ;", ";");
            option = option.Replace(";  ; ", ";");
            option = option.Replace(";pcre", "; pcre");
            option = option.Replace("content:\"\";", "");
            return option;
        }

        //문법 체크
        public int headerChecker(rHeader rh)
        {
            return 0;
        }

        public int optionChecker(rOption rOpt)
        {
            //1. 옵션의 값 체크는 옵션 항목에서 현재 필터링 작업된 숫자, 문자들이 맞는지 만 확인

            //2-1. 헤더의 각 옵션 사이의 구분자(공백)가 정상적으로 사용됐는지 확인,
            //2-2. 헤더와 옵션을 구분하는 구분자 “(“, “)”가 정상적으로 사용 됐는지 확인.
            //2-3. 각 옵션들의 구분자 “;”가 정상적으로 사용 됐는지 확인
            //2-4. 각 옵션들의 옵션명과 값들의 구분자가 “:”가 정상적으로 사용됐는지 확인

            return 0;
        }

        public static bool IsIPv4(string value)
        {
            IPAddress address;

            if (IPAddress.TryParse(value, out address))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
        public int rParse_HiddenEditor(string optItem, string optItem_text)
        {
            string foo;
            // -1 잘못된 옵션 값을 입력 하였습니다. 수정 하시기 바랍니다. 0 비어있음 1 정상적으로 들어옴
            switch (optItem)
            {
                //숫자 및 word등록 스트링만 사용 가능
                case "isdataat":
                case "ttl":
                case "dsize":
                case "itype":
                case "icode":
                    foo = optItem.Replace(optItem_text, "");
                    if (!IsNumeric(foo))
                    {
                        return -1;
                    }
                    break;

                //등록 스트링만 사용 가능
                case "flags":
                case "flow":
                    foo = optItem.Replace(optItem_text, "");
                    if (!string.IsNullOrEmpty(foo))
                    {
                        return -1;
                    }
                    break;

                //숫자만 가능
                case "SourcePort":
                case "DestPort":
                case "offset":
                case "distance":
                case "depth":
                case "within":
                case "icmp_id":
                case "icmp_seq":
                case "count":
                case "seconds":
                case "priority":
                case "rev":
                    if (!IsNumeric(optItem_text))
                    {
                        return -1;
                    }
                    break;

                case "content":
                case "pcre":
                case "msg":
                case "sid":
                    int startIdx;
                    int endIdx;
                    startIdx = optItem_text.IndexOf("\"");
                    if (startIdx < 0)
                    {
                        return -1;
                    }
                    endIdx = optItem_text.IndexOf("\"", startIdx + 1);
                    if (endIdx != optItem_text.Length - 1)
                    {
                        return -1;
                    }
                    break;
            }
            return 1;

        }

        public int rParse(string txtRule, rHeader rh, rOption rOpt)
        {
            string _txtRule;
            Tuple<rHeader, rOption> result = new Tuple<rHeader, rOption>(rh, rOpt);

            //alert tcp any 64581 -> any 80 (pcre:"(?:HTTP\/1\.1|keep\-alive)"; contents:"slashdot.org"; depth:12; offset:88;  ;)

            //2-1. 헤더의 각 옵션 사이의 구분자(공백)가 정상적으로 사용됐는지 확인 
            //     -> rh의 모든 필드가 not null이면 OK
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            _txtRule = regex.Replace(txtRule, @" ");

            string[] _header = _txtRule.Split(' ');

            if (_header.Count() < 7)
                return -99;

            rh.Action = _header[0];
            rh.Protocol = _header[1];
            rh.SourceIP = _header[2];
            rh.SourcePort = _header[3];
            rh.Direction = _header[4];
            rh.DestIP = _header[5];
            rh.DestPort = _header[6];

            //전체적인 오류 번호 수정 -4 소스포트, -7 DestPort 에러
            if (!rh.Action.Equals("alert") && !rh.Action.Equals("drop"))
                return -1;
            if (!rh.Protocol.Equals("tcp") && !rh.Protocol.Equals("udp") && !rh.Protocol.Equals("icmp") && !rh.Protocol.Equals("ip"))
                return -2;
            if (!rh.SourceIP.Equals("any") && !IsIPv4(rh.SourceIP))
                return -3;
            if (!rh.SourcePort.Equals("any") && rParse_HiddenEditor("SourcePort", rh.SourcePort) != 1)
                return -4;
            if (!rh.Direction.Equals("->") && !rh.Direction.Equals("<>"))
                return -5;
            if (!rh.DestIP.Equals("any") && !IsIPv4(rh.DestIP))
                return -6;
            if (!rh.DestPort.Equals("any") && rParse_HiddenEditor("DestPort", rh.DestPort) != 1)
                return -7;

            //2-2. 헤더와 옵션을 구분하는 구분자 “(“, “)”가 정상적으로 사용 됐는지 확인.
            if ((_header[7][0] != '(') || !_header[_header.Count() - 1].Contains(')'))
                return -9;

            //2-3. 각 옵션들의 구분자 “;”가 정상적으로 사용 됐는지 확인
            //2-4. 각 옵션들의 옵션명과 값들의 구분자가 “:”가 정상적으로 사용됐는지 확인
            _txtRule = txtRule.Substring(txtRule.IndexOf('('));
            _header = _txtRule.Split(';');

            string[] optItem = { "msg", "pcre", "byte_test", "byte_jump", "ttl", "dsize" , "content", "depth", "offset",
                               "flags" , "flow" ,  "flowbits" , "itype" , "icode" , "icmp_id" , "icmp_seq" , "trashold", "distance", "within", "sid","priority","rev"};
            foreach (string foo in _header)
            {
                string bar = foo.Replace(" ", "");
                if (string.IsNullOrEmpty(bar) || bar.Equals(")"))
                    continue;
                string bar2 = bar.Split(':')[0];
                if (bar2[0] == '(')
                {
                    bar2 = bar2.Remove(0, 1);
                }
                if (bar2 != "nocase" && bar2 != "rawbytes")
                {
                    if (!optItem.Contains(bar2))
                        return -10;  //정의되지 않은 옵션 사용
                    string bar3 = bar.Replace(bar.Split(':')[0] + ":", "");
                    if (rParse_HiddenEditor(bar2, bar3) != 1)
                        return -11;  //정의되지 않은 옵션 사용
                }
            }

            return 0;
        }

        public string rParseStr(string txtRule, rHeader rh, rOption rOpt)
        {
            string _txtRule;
            Tuple<rHeader, rOption> result = new Tuple<rHeader, rOption>(rh, rOpt);

            //alert tcp any 64581 -> any 80 (pcre:"(?:HTTP\/1\.1|keep\-alive)"; contents:"slashdot.org"; depth:12; offset:88;  ;)

            //2-1. 헤더의 각 옵션 사이의 구분자(공백)가 정상적으로 사용됐는지 확인 
            //     -> rh의 모든 필드가 not null이면 OK
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            _txtRule = regex.Replace(txtRule, @" ");

            string[] _header = _txtRule.Split(' ');

            if (_header.Count() < 7)
                return "기본적인 문법 구성이 이루어지지 않았습니다.";

            rh.Action = _header[0];
            rh.Protocol = _header[1];
            rh.SourceIP = _header[2];
            rh.SourcePort = _header[3];
            rh.Direction = _header[4];
            rh.DestIP = _header[5];
            rh.DestPort = _header[6];

            if (!rh.Action.Equals("alert") && !rh.Action.Equals("drop"))
                return rh.Action;
            if (!rh.Protocol.Equals("tcp") && !rh.Protocol.Equals("udp") && !rh.Protocol.Equals("icmp") && !rh.Protocol.Equals("ip"))
                return rh.Protocol;
            if (!rh.SourceIP.Equals("any") && !IsIPv4(rh.SourceIP))
                return rh.SourceIP;
            if (!rh.SourcePort.Equals("any") && rParse_HiddenEditor("SourcePort", rh.SourcePort) != 1)
                return rh.SourcePort;
            if (!rh.Direction.Equals("->") && !rh.Direction.Equals("<>"))
                return rh.Direction;
            if (!rh.DestIP.Equals("any") && !IsIPv4(rh.DestIP))
                return rh.DestIP;
            if (!rh.DestPort.Equals("any") && rParse_HiddenEditor("SourcePort", rh.DestPort) != 1)
                return rh.DestPort;

            //2-2. 헤더와 옵션을 구분하는 구분자 “(“, “)”가 정상적으로 사용 됐는지 확인.
            if ((_header[7][0] != '(') || !_header[_header.Count() - 1].Contains(')'))
                return "헤더와 옵션을 구분하는 구분자 '(', ')'가 사용되지 않았습니다.";

            //2-3. 각 옵션들의 구분자 “;”가 정상적으로 사용 됐는지 확인
            //2-4. 각 옵션들의 옵션명과 값들의 구분자가 “:”가 정상적으로 사용됐는지 확인
            _txtRule = txtRule.Substring(txtRule.IndexOf('('));
            _header = _txtRule.Split(';');

            string[] optItem = { "msg", "pcre", "byte_test", "byte_jump", "ttl", "dsize" , "content", "depth", "offset",
                                 "flags" , "flow" ,  "flowbits" , "itype" , "icode" , "icmp_id" , "icmp_seq" , "trashold", "distance", "within", "sid"};  
            foreach (string foo in _header)
            {
                string bar = foo.Replace(" ", "");
                if (string.IsNullOrEmpty(bar) || bar.Equals(")"))
                    continue;
                string bar2 = bar.Split(':')[0];
                if (bar2[0] == '(')
                {
                    bar2 = bar2.Remove(0, 1);
                    bar = bar.Remove(0, 1);
                }
                if (bar2 != "nocase" || bar2 != "rawbytes")
                {
                    if (!optItem.Contains(bar2))
                    {
                        return bar;
                    }
                    string bar3 = bar.Replace(bar.Split(':')[0] + ":", "");
                    if (rParse_HiddenEditor(bar2, bar3) != 1)
                    {
                        return bar;  //정의되지 않은 옵션 사용
                    }
                }
            }

            return "정상적으로 설정되었습니다.";
        }
    }


    class rHeader
    {
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private string protocol;

        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        private string sourceIP;

        public string SourceIP
        {
            get { return sourceIP; }
            set { sourceIP = value; }
        }
        private string sourcePort;

        public string SourcePort
        {
            get { return sourcePort; }
            set { sourcePort = value; }
        }

        private string direction;

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private string destIP;

        public string DestIP
        {
            get { return destIP; }
            set { destIP = value; }
        }
        private string destPort;

        public string DestPort
        {
            get { return destPort; }
            set { destPort = value; }
        }

    }

    class rPayload
    {
        //Payload
        //private string contents;

        //public string Contents
        //{
        //    get { return contents; }
        //    set { contents = value; }
        //}
        
    }

    class rOption
    {
        //Meta Data
        private string msg;

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        private List<rPayload> payload = new List<rPayload>();

        internal List<rPayload> Payload
        {
            get { return payload; }
            set { payload = value; }
        }

        private string isdataat;

        public string Isdataat
        {
            get { return isdataat; }
            set { isdataat = value; }
        }
        private string pcre;

        public string Pcre
        {
            get { return pcre; }
            set { pcre = value; }
        }
        private string byte_test;

        public string Byte_test
        {
            get { return byte_test; }
            set { byte_test = value; }
        }
        private string byte_jump;

        public string Byte_jump
        {
            get { return byte_jump; }
            set { byte_jump = value; }
        }

        //Non-Payload
        private string ttl;

        public string Ttl
        {
            get { return ttl; }
            set { ttl = value; }
        }
        private string dsize;

        public string Dsize
        {
            get { return dsize; }
            set { dsize = value; }
        }
        private string flags;

        public string Flags
        {
            get { return flags; }
            set { flags = value; }
        }
        private string flow;

        public string Flow
        {
            get { return flow; }
            set { flow = value; }
        }
        private string flowbits;

        public string Flowbits
        {
            get { return flowbits; }
            set { flowbits = value; }
        }
        private string itype;

        public string Itype
        {
            get { return itype; }
            set { itype = value; }
        }
        private string icode;

        public string Icode
        {
            get { return icode; }
            set { icode = value; }
        }
        private string icmp_id;

        public string Icmp_id
        {
            get { return icmp_id; }
            set { icmp_id = value; }
        }
        private string icmp_seq;

        public string Icmp_seq
        {
            get { return icmp_seq; }
            set { icmp_seq = value; }
        }

        //Threshholding
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string track;

        public string Track
        {
            get { return track; }
            set { track = value; }
        }
        private string count;

        public string Count
        {
            get { return count; }
            set { count = value; }
        }
        private string second;

        public string Second
        {
            get { return second; }
            set { second = value; }
        }
        
        //Content
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string nocase;

        public string Nocase
        {
            get { return nocase; }
            set { nocase = value; }
        }
        private string rawbytes;

        public string Rawbytes
        {
            get { return rawbytes; }
            set { rawbytes = value; }
        }
        private string depth;

        public string Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        private string offset;

        public string Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        private string distance;

        public string Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        private string within;

        public string Within
        {
            get { return within; }
            set { within = value; }
        }
        private string sid;
        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }
        private string priority;
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        private string rev;
        public string Rev
        {
            get { return rev; }
            set { rev = value; }
        }
    }
}
