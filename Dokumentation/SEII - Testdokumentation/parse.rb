#!/usr/bin/ruby

def die(s)
  puts s
  exit -1
end

die "usage: parse.rb <filename>" if not ARGV[0]

ARGV.each do
|filename|
  f = File.open filename

  data = /\#\s*([^\n]+)/.match f.readline
  die "not a test report!" if not data
#  puts data[1]

  cases = 0
  fails = -2

  f.each do
    |s|
    data = /^\*\s/.match s
    if data then
      cases += 1
      fails += 1 if not /\sok\s/.match s
    end
  end

  puts cases.to_s + "\t" + fails.to_s + "\t" + (fails * 1000 / cases / 10.0).to_s

  f.close
end
